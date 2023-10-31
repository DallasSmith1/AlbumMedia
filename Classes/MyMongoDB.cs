using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using AlbumMedia.Classes;
using System.Windows.Media;
using System.IO;

namespace AlbumMedia
{
    public class MyMongoDB
    {
        private static MongoClient dbClient = null;
        private static IMongoDatabase dbDatabase = null;

        private static List<Movie> recentMovieCollection = new List<Movie> ();
        private static List<MovieGenre> recentMovieGenreCollection = new List<MovieGenre> ();

        /// <summary>
        /// creates a connection tot he database
        /// </summary>
        /// <returns></returns>
        public static bool Connect()
        {
            dbClient = new MongoClient(Properties.Settings.Default.ATLASCONNECTIONSTRING);
            if (dbClient == null ) 
            {
                return false;
            }
            else
            {
                dbDatabase = dbClient.GetDatabase(Properties.Settings.Default.DATABASE);
                if (dbDatabase == null )
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// adds a user to the database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static void CreateUser(User user) 
        {
            Connect();

            if(UserExists(user))
            {
                throw new UserAlreadyExistsException("Username already in use.");
            }
            else if (user.Username == "Movie")
            {
                throw new UserAlreadyExistsException("Unauthorized username");
            }
            else
            {
                var collection = dbDatabase.GetCollection<BsonDocument>("Users");
                BsonDocument newUser = new BsonDocument { {"Username", user.Username },
                        {"Password", BCrypt.Net.BCrypt.HashPassword(user.Password) },
                        {"IsAdmin", user.IsAdmin },
                        {"Email", user.Email } };
                collection.InsertOne(newUser);
                Directory.CreateDirectory(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + user.Username);
            }
        }

        /// <summary>
        /// checks to see if the given user exists
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UserExists(User user) 
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Username", user.Username);

            var collection = dbDatabase.GetCollection<BsonDocument>("Users");

            var foundUser = collection.Find(filter).FirstOrDefault();

            if (foundUser != null) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// gets the selected user from the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static User GetUser(string username, string pass)
        {
            Connect();

            User foundUser = null;

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);

            var collection = dbDatabase.GetCollection<BsonDocument>("Users");

            var user = collection.Find(filter).FirstOrDefault();

            if (user == null)
            {
                filter = Builders<BsonDocument>.Filter.Eq("Email", username);

                collection = dbDatabase.GetCollection<BsonDocument>("Users");

                user = collection.Find(filter).FirstOrDefault();
            }

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(pass, (string)user.GetElement("Password").Value))
                {
                    foundUser = new User(user.GetElement("_id").Value.ToString(), user.GetElement("Username").Value.ToString(), pass, (bool)user.GetElement("IsAdmin").Value, user.GetElement("Email").Value.ToString());
                }
                else
                {
                    if (GetTemporaryPassword(user.GetElement("Email").Value.ToString()) != null)
                    {
                        if (BCrypt.Net.BCrypt.Verify(pass, GetTemporaryPassword(user.GetElement("Email").Value.ToString())))
                        {
                            throw new TemporaryPasswordException();
                        }
                        else
                        {
                            throw new UserNotFoundException("Incorrect password.");
                        }
                    }
                    else
                    {
                        throw new UserNotFoundException("Incorrect password.");
                    }
                }
            }
            else
            {
                throw new UserNotFoundException(username + " is not a registered username.");
            }
            return foundUser;
        }

        /// <summary>
        /// gets a user based on the email, but does not return a password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException"></exception>
        public static User GetUser(string email)
        {
            Connect();

            User foundUser = null;

            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);

            var collection = dbDatabase.GetCollection<BsonDocument>("Users");

            var user = collection.Find(filter).FirstOrDefault();

            if (user != null)
            {
                foundUser = new User(user.GetElement("_id").Value.ToString(), user.GetElement("Username").Value.ToString(), "", (bool)user.GetElement("IsAdmin").Value, user.GetElement("Email").Value.ToString());
            }
            return foundUser;
        }

        /// <summary>
        /// gets all user names in db
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllUsers()
        {
            var collection = dbDatabase.GetCollection<BsonDocument>("Users");

            var users = collection.Find(_ => true).ToList();

            List<string> userList = new List<string> { };

            for (int i = 0; i < users.Count; i++)
            {
                userList.Add(users[i].GetElement("Username").Value.ToString());
            }

            return userList;
        }

        /// <summary>
        /// gets all movies
        /// </summary>
        /// <returns></returns>
        public static List<Movie> GetAllMovies()
        {
            Connect();

            recentMovieCollection.Clear();

            var collection = dbDatabase.GetCollection<BsonDocument>("Movies");

            var movies = collection.Find(_ => true).ToList();

            List<Movie> movieList = new List<Movie> { };

            for(int i = 0; i < movies.Count; i++)
            {
                Movie newMovie = new Movie(movies[i].GetElement("Title").Value.ToString(), 
                    movies[i].GetElement("Description").Value.ToString(), 
                    movies[i].GetElement("File").Value.ToString(), 
                    movies[i].GetElement("Poster").Value.ToString(), 
                    movies[i].GetElement("ReleaseYear").Value.ToString(), 
                    movies[i].GetElement("Company").Value.ToString());
                movieList.Add(newMovie);
                recentMovieCollection.Add(newMovie);
            }
            return movieList;
        }

        /// <summary>
        /// updates the password of the specified user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static User UpdatePassword(string username, string password)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);

            var update = Builders<BsonDocument>.Update.Set("Password", BCrypt.Net.BCrypt.HashPassword(password));

            var collection = dbDatabase.GetCollection<BsonDocument>("Users");

            collection.UpdateOne(filter, update);

            filter = Builders<BsonDocument>.Filter.Eq("Username", username);

            collection = dbDatabase.GetCollection<BsonDocument>("Users");

            var user = collection.Find(filter).FirstOrDefault();

            return new User(user.GetElement("_id").Value.ToString(), user.GetElement("Username").Value.ToString(), password, (bool)user.GetElement("IsAdmin").Value, user.GetElement("Email").Value.ToString());
        }

        /// <summary>
        /// deletes a user from the databse
        /// </summary>
        /// <param name="username"></param>
        public static void DeleteUser(string username)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Username", username);

            var collection = dbDatabase.GetCollection<BsonDocument>("Users");

            collection.DeleteOne(filter);
            DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.SHAREDFOLDER + "\\Users\\" + username);
            foreach (FileInfo file in di.EnumerateFiles())
            {
                try
                {
                    file.Delete();
                }
                catch { }
            }
            try
            {
                di.Delete();
            }
            catch { }

            filter = Builders<BsonDocument>.Filter.Eq("User", username);

            collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            collection.DeleteMany(filter);
        }

        /// <summary>
        /// gets movie title
        /// </summary>
        /// <returns></returns>
        public static Movie GetMovie(string title)
        {
            Connect();

            var collection = dbDatabase.GetCollection<BsonDocument>("Movies");

            var filter = Builders<BsonDocument>.Filter.Eq("Title", title);

            var movie = collection.Find(filter).FirstOrDefault(); ;

            return new Movie(movie.GetElement("Title").Value.ToString(),
                   movie.GetElement("Description").Value.ToString(),
                   movie.GetElement("File").Value.ToString(),
                   movie.GetElement("Poster").Value.ToString(),
                   movie.GetElement("ReleaseYear").Value.ToString(),
                   movie.GetElement("Company").Value.ToString());
        }

        /// <summary>
        /// gets the movie based on the poster file
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Movie GetMovie(ImageSource bitmap)
        {
            string[] poster = bitmap.ToString().Split('/');
            foreach (Movie movie in recentMovieCollection)
            {
                if (movie.Poster == poster[poster.Count()-1])
                {
                    return movie;
                }
            }
            return null;
        }

        /// <summary>
        /// gets all the movies and their genres
        /// </summary>
        /// <returns></returns>
        public static List<MovieGenre> GetMovieGenreList()
        {
            Connect();

            recentMovieGenreCollection.Clear();

            var collection = dbDatabase.GetCollection<BsonDocument>("Genres");

            var movies = collection.Find(_ => true).ToList();

            List<MovieGenre> movieList = new List<MovieGenre> { };

            for (int i = 0; i < movies.Count; i++)
            {
                MovieGenre newMovie = new MovieGenre(movies[i].GetElement("Title").Value.ToString(),
                    (bool)movies[i].GetElement("Horror").Value,
                    (bool)movies[i].GetElement("Disney").Value,
                    (bool)movies[i].GetElement("Comedy").Value,
                    (bool)movies[i].GetElement("Animated").Value,
                    (bool)movies[i].GetElement("ScienceFiction").Value,
                    (bool)movies[i].GetElement("Action").Value,
                    (bool)movies[i].GetElement("Adventure").Value,
                    (bool)movies[i].GetElement("SuperHero").Value,
                    (bool)movies[i].GetElement("StarWars").Value,
                    (bool)movies[i].GetElement("Jurassic").Value,
                    (bool)movies[i].GetElement("Kids").Value,
                    (bool)movies[i].GetElement("Adult").Value,
                    (bool)movies[i].GetElement("Romance").Value,
                    (bool)movies[i].GetElement("Drama").Value,
                    (bool)movies[i].GetElement("Thriller").Value);
                movieList.Add(newMovie);
                recentMovieGenreCollection.Add(newMovie);
            }
            return movieList;
        }

        /// <summary>
        /// Gets a list of movies from a specific genre
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public static List<MovieGenre> GetMovieGenreList(string genre)
        {
            Connect();

            var collection = dbDatabase.GetCollection<BsonDocument>("Genres");

            var filter = Builders<BsonDocument>.Filter.Eq(genre, true);

            var movies = collection.Find(filter).ToList(); ;

            List<MovieGenre> movieList = new List<MovieGenre> { };

            for (int i = 0; i < movies.Count; i++)
            {
                MovieGenre newMovie = new MovieGenre(movies[i].GetElement("Title").Value.ToString(),
                    (bool)movies[i].GetElement("Horror").Value,
                    (bool)movies[i].GetElement("Disney").Value,
                    (bool)movies[i].GetElement("Comedy").Value,
                    (bool)movies[i].GetElement("Animated").Value,
                    (bool)movies[i].GetElement("ScienceFiction").Value,
                    (bool)movies[i].GetElement("Action").Value,
                    (bool)movies[i].GetElement("Adventure").Value,
                    (bool)movies[i].GetElement("SuperHero").Value,
                    (bool)movies[i].GetElement("StarWars").Value,
                    (bool)movies[i].GetElement("Jurassic").Value,
                    (bool)movies[i].GetElement("Kids").Value,
                    (bool)movies[i].GetElement("Adult").Value,
                    (bool)movies[i].GetElement("Romance").Value,
                    (bool)movies[i].GetElement("Drama").Value,
                    (bool)movies[i].GetElement("Thriller").Value);
                movieList.Add(newMovie);
            }
            return movieList;
        }

        /// <summary>
        /// searches for a title that matches or has the given string in it
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static List<MovieGenre> MovieSearch(string search)
        {
            Connect();

            var collection = dbDatabase.GetCollection<BsonDocument>("Genres");

            var movies = collection.Find(_ => true).ToList();

            List<MovieGenre> movieList = new List<MovieGenre> { };

            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].GetElement("Title").Value.ToString().ToLower().Contains(search.ToLower()))
                {
                    MovieGenre newMovie = new MovieGenre(movies[i].GetElement("Title").Value.ToString(),
                        (bool)movies[i].GetElement("Horror").Value,
                        (bool)movies[i].GetElement("Disney").Value,
                        (bool)movies[i].GetElement("Comedy").Value,
                        (bool)movies[i].GetElement("Animated").Value,
                        (bool)movies[i].GetElement("ScienceFiction").Value,
                        (bool)movies[i].GetElement("Action").Value,
                        (bool)movies[i].GetElement("Adventure").Value,
                        (bool)movies[i].GetElement("SuperHero").Value,
                        (bool)movies[i].GetElement("StarWars").Value,
                        (bool)movies[i].GetElement("Jurassic").Value,
                        (bool)movies[i].GetElement("Kids").Value,
                        (bool)movies[i].GetElement("Adult").Value,
                        (bool)movies[i].GetElement("Romance").Value,
                        (bool)movies[i].GetElement("Drama").Value,
                        (bool)movies[i].GetElement("Thriller").Value);
                    movieList.Add(newMovie);
                }
            }
            return movieList;
        }


        /// <summary>
        /// returns a list of the genres for the given movie title. Returns in a string format
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GetMovieGenres(string title)
        {
            MovieGenre movie = MovieSearch(title)[0];

            string output = "";

            if (movie.Action)
            {
                output += " Action,";
            }
            if (movie.Drama)
            {
                output += " Drama,";
            }
            if (movie.Romance)
            {
                output += " Romance,";
            }
            if (movie.StarWars)
            {
                output += " Star Wars,";
            }
            if (movie.Comedy)
            {
                output += " Comedy,";
            }
            if (movie.Adult)
            {
                output += " Adult,";
            }
            if (movie.Advanture)
            {
                output += " Adventure,";
            }
            if (movie.Animated)
            {
                output += " Animated,";
            }
            if (movie.Disney)
            {
                output += " Disney,";
            }
            if (movie.Horror)
            {
                output += " Horror,";
            }
            if (movie.Jurassic)
            {
                output += " Jurassic,";
            }
            if (movie.Kids)
            {
                output += " Kids,";
            }
            if (movie.ScienceFiction)
            {
                output += " Science Fiction,";
            }
            if (movie.SuperHero)
            {
                output += " Super Hero,";
            }
            if (movie.Thriller)
            {
                output += " Thriller";
            }

            return output;
        }


        /// <summary>
        /// updates the genre in the database
        /// </summary>
        /// <param name="movie"></param>
        public static void UpdateMovieInfo(MovieGenre movieGenre, Movie movie, string originalTitle)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Title", originalTitle);

            var collection = dbDatabase.GetCollection<BsonDocument>("Genres");

            collection.DeleteOne(filter);

            BsonDocument newGenre = new BsonDocument { {"Title", movieGenre.MovieTitle },
                        {"Horror", movieGenre.Horror },
                        {"Disney", movieGenre.Disney },
                        {"Comedy", movieGenre.Comedy },
                        {"Animated", movieGenre.Animated },
                        {"ScienceFiction", movieGenre.ScienceFiction },
                        {"Action", movieGenre.Action },
                        {"Adventure", movieGenre.Advanture },
                        {"SuperHero", movieGenre.SuperHero },
                        {"StarWars", movieGenre.StarWars },
                        {"Jurassic", movieGenre.Jurassic },
                        {"Kids", movieGenre.Kids },
                        {"Adult", movieGenre.Adult },
                        {"Romance", movieGenre.Romance },
                        {"Drama", movieGenre.Drama },
                        {"Thriller", movieGenre.Thriller }};

            collection.InsertOne(newGenre);

            filter = Builders<BsonDocument>.Filter.Eq("Title", originalTitle);

            collection = dbDatabase.GetCollection<BsonDocument>("Movies");

            collection.DeleteOne(filter);

            BsonDocument newMovie = new BsonDocument { {"Title", movie.Title },
                        {"ReleaseYear", movie.ReleaseYear },
                        {"Company", movie.Company },
                        {"Description", movie.Description },
                        {"File", movie.File },
                        {"Poster", movie.Poster }};

            collection.InsertOne(newMovie);
        }

        /// <summary>
        /// Deletes a movie from the database and removes all files associated with it
        /// </summary>
        /// <param name="movie"></param>
        public static void DeleteMovie(Movie movie)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Title", movie.Title);

            var collection = dbDatabase.GetCollection<BsonDocument>("Movies");

            collection.DeleteOne(filter);

            collection = dbDatabase.GetCollection<BsonDocument>("Genres");

            collection.DeleteOne(filter);
        }

        /// <summary>
        /// add a new movie to the database
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="movieGenre"></param>
        public static void AddMovie(Movie movie, MovieGenre movieGenre)
        {
            Connect();

            var collection = dbDatabase.GetCollection<BsonDocument>("Genres");

            BsonDocument newGenre = new BsonDocument { {"Title", movieGenre.MovieTitle },
                        {"Horror", movieGenre.Horror },
                        {"Disney", movieGenre.Disney },
                        {"Comedy", movieGenre.Comedy },
                        {"Animated", movieGenre.Animated },
                        {"ScienceFiction", movieGenre.ScienceFiction },
                        {"Action", movieGenre.Action },
                        {"Adventure", movieGenre.Advanture },
                        {"SuperHero", movieGenre.SuperHero },
                        {"StarWars", movieGenre.StarWars },
                        {"Jurassic", movieGenre.Jurassic },
                        {"Kids", movieGenre.Kids },
                        {"Adult", movieGenre.Adult },
                        {"Romance", movieGenre.Romance },
                        {"Drama", movieGenre.Drama },
                        {"Thriller", movieGenre.Thriller }};

            collection.InsertOne(newGenre);

            collection = dbDatabase.GetCollection<BsonDocument>("Movies");

            BsonDocument newMovie = new BsonDocument { {"Title", movie.Title },
                        {"ReleaseYear", movie.ReleaseYear },
                        {"Company", movie.Company },
                        {"Description", movie.Description },
                        {"File", movie.File },
                        {"Poster", movie.Poster }};

            collection.InsertOne(newMovie);
        }

        /// <summary>
        /// add a photo to the database
        /// </summary>
        /// <param name="photo"></param>
        public static void UploadPhoto(Photo photo)
        {
            if (photo.subject == null)
            {
                photo.subject = "";
            }

            Connect();

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            BsonDocument newPhoto = new BsonDocument { {"User", photo.user.ToString() },
                        {"DateTaken", new BsonDateTime(photo.dateTaken)},
                        {"DateUploaded", new BsonDateTime(photo.dateUploaded) },
                        {"Location", photo.location.ToString() },
                        {"Keywords", photo.keywords.ToString() },
                        {"Subject", photo.subject.ToString() },
                        {"IsPublic", new BsonBoolean(photo.isPublic) },
                        {"File", photo.file.ToString() } };

            collection.InsertOne(newPhoto);
        }

        /// <summary>
        /// updates photo in the database
        /// </summary>
        /// <param name="file"></param>
        public static void UpdatePhoto(Photo photo)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("File", photo.file);

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            collection.DeleteOne(filter);

            BsonDocument newPhoto = new BsonDocument { {"User", photo.user.ToString() },
                        {"DateTaken", new BsonDateTime(photo.dateTaken)},
                        {"DateUploaded", new BsonDateTime(photo.dateUploaded) },
                        {"Location", photo.location.ToString() },
                        {"Keywords", photo.keywords.ToString() },
                        {"Subject", photo.subject.ToString() },
                        {"IsPublic", new BsonBoolean(photo.isPublic) },
                        {"File", photo.file.ToString() } };

            collection.InsertOne(newPhoto);
        }

        /// <summary>
        /// delete a photo from the database
        /// </summary>
        /// <param name="photo"></param>
        public static void DeletePhoto(Photo photo)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("File", photo.file);

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            collection.DeleteOne(filter);
        }

        /// <summary>
        /// delete a photo from the database
        /// </summary>
        /// <param name="photo"></param>
        public static void DeletePhoto(string file)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("File", file);

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            collection.DeleteOne(filter);
        }


        /// <summary>
        /// get all photos in given range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static List<Photo> GetPhotos(string sort, string user)
        {
            Connect();

            List<Photo> photoList = new List<Photo> { };

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            List<BsonDocument> photos = new List<BsonDocument>();

            var filter = Builders<BsonDocument>.Filter.Eq("User", user);

            if (sort == "Date Photo Taken (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: -1}").ToList();
            }
            else if (sort == "Date Photo Taken (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: 1}").ToList();
            }
            else if (sort == "Date Uploaded (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: -1}").ToList();
            }
            else if (sort == "Date Uploaded (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: 1}").ToList();
            }

            for (int i = 0; i < photos.Count; i++)
            {
                Photo newPhoto = new Photo(
                    photos[i].GetElement("File").Value.ToString(),
                    (DateTime)photos[i].GetElement("DateTaken").Value.AsBsonDateTime,
                    (DateTime)photos[i].GetElement("DateUploaded").Value.AsBsonDateTime,
                    photos[i].GetElement("Location").Value.ToString(),
                    photos[i].GetElement("Keywords").Value.ToString(),
                    photos[i].GetElement("Subject").Value.ToString(),
                    photos[i].GetElement("User").Value.ToString(),
                    photos[i].GetElement("IsPublic").Value.AsBoolean);

                photoList.Add(newPhoto);
            }

            return photoList;
        }

        /// <summary>
        /// gets searched photos in range
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static List<Photo> GetPhotos(string sort, string search, string user)
        {
            Connect();

            List<Photo> photoList = new List<Photo> { };

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            List<BsonDocument> photos = new List<BsonDocument>();

            var filter = Builders<BsonDocument>.Filter.Eq("User", user);

            if (sort == "Date Photo Taken (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: -1}").ToList();
            }
            else if (sort == "Date Photo Taken (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: 1}").ToList();
            }
            else if (sort == "Date Uploaded (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: -1}").ToList();
            }
            else if (sort == "Date Uploaded (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: 1}").ToList();
            }

            for (int i = 0; i < photos.Count; i++)
            {
                Photo newPhoto = new Photo(
                    photos[i].GetElement("File").Value.ToString(),
                    (DateTime)photos[i].GetElement("DateTaken").Value.AsBsonDateTime,
                    (DateTime)photos[i].GetElement("DateUploaded").Value.AsBsonDateTime,
                    photos[i].GetElement("Location").Value.ToString(),
                    photos[i].GetElement("Keywords").Value.ToString(),
                    photos[i].GetElement("Subject").Value.ToString(),
                    photos[i].GetElement("User").Value.ToString(),
                    photos[i].GetElement("IsPublic").Value.AsBoolean);

                if (newPhoto.file.ToLower().Contains(search.ToLower()) ||
                    newPhoto.location.ToLower().Contains(search.ToLower()) ||
                    newPhoto.subject.ToLower().Contains(search.ToLower()) ||
                    newPhoto.dateTaken.ToString().Contains(search.ToLower()) ||
                    newPhoto.dateUploaded.ToString().Contains(search.ToLower()) ||
                    newPhoto.keywords.ToLower().Contains(search.ToLower()))
                {
                    photoList.Add(newPhoto);
                }
            }

            return photoList;
        }

        /// <summary>
        /// gets all shared photos
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<Photo> GetSharedPhotos(string sort)
        {
            Connect();

            List<Photo> photoList = new List<Photo> { };

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            List<BsonDocument> photos = new List<BsonDocument>();

            var filter = Builders<BsonDocument>.Filter.Eq("IsPublic", true);

            if (sort == "Date Photo Taken (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: -1}").ToList();
            }
            else if (sort == "Date Photo Taken (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: 1}").ToList();
            }
            else if (sort == "Date Uploaded (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: -1}").ToList();
            }
            else if (sort == "Date Uploaded (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: 1}").ToList();
            }

            for (int i = 0; i < photos.Count; i++)
            {
                Photo newPhoto = new Photo(
                    photos[i].GetElement("File").Value.ToString(),
                    (DateTime)photos[i].GetElement("DateTaken").Value.AsBsonDateTime,
                    (DateTime)photos[i].GetElement("DateUploaded").Value.AsBsonDateTime,
                    photos[i].GetElement("Location").Value.ToString(),
                    photos[i].GetElement("Keywords").Value.ToString(),
                    photos[i].GetElement("Subject").Value.ToString(),
                    photos[i].GetElement("User").Value.ToString(),
                    photos[i].GetElement("IsPublic").Value.AsBoolean);

                photoList.Add(newPhoto);
            }

            return photoList;
        }


        /// <summary>
        /// gets all shared photos with search
        /// </summary>
        /// <param name="sort"></param>
        /// <param name="search"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<Photo> GetSharedPhotos(string sort, string search)
        {
            Connect();

            List<Photo> photoList = new List<Photo> { };

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            List<BsonDocument> photos = new List<BsonDocument>();

            var filter = Builders<BsonDocument>.Filter.Eq("IsPublic", true);

            if (sort == "Date Photo Taken (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: -1}").ToList();
            }
            else if (sort == "Date Photo Taken (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateTaken: 1}").ToList();
            }
            else if (sort == "Date Uploaded (New-Old)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: -1}").ToList();
            }
            else if (sort == "Date Uploaded (Old-New)")
            {
                photos = collection.Find(filter).Sort("{DateUploaded: 1}").ToList();
            }

            for (int i = 0; i < photos.Count; i++)
            {
                Photo newPhoto = new Photo(
                    photos[i].GetElement("File").Value.ToString(),
                    (DateTime)photos[i].GetElement("DateTaken").Value.AsBsonDateTime,
                    (DateTime)photos[i].GetElement("DateUploaded").Value.AsBsonDateTime,
                    photos[i].GetElement("Location").Value.ToString(),
                    photos[i].GetElement("Keywords").Value.ToString(),
                    photos[i].GetElement("Subject").Value.ToString(),
                    photos[i].GetElement("User").Value.ToString(),
                    photos[i].GetElement("IsPublic").Value.AsBoolean);

                if (newPhoto.file.ToLower().Contains(search.ToLower()) ||
                    newPhoto.location.ToLower().Contains(search.ToLower()) ||
                    newPhoto.subject.ToLower().Contains(search.ToLower()) ||
                    newPhoto.dateTaken.ToString().Contains(search.ToLower()) ||
                    newPhoto.dateUploaded.ToString().Contains(search.ToLower()) ||
                    newPhoto.keywords.ToLower().Contains(search.ToLower()) ||
                    newPhoto.user.ToLower().Contains(search.ToLower()))
                {
                    photoList.Add(newPhoto);
                }
            }

            return photoList;
        }

        [Obsolete]
        public static Photo GetPhoto(string file)
        {
            Connect();

            List<Photo> photoList = new List<Photo> { };

            var collection = dbDatabase.GetCollection<BsonDocument>("Photos");

            var filter = Builders<BsonDocument>.Filter.Eq("File", file);

            foreach (BsonDocument photo in collection.Find(filter).ToList()) 
            {
                return new Photo(photo.GetElement("File").Value.ToString(), photo.GetElement("DateTaken").Value.AsDateTime, photo.GetElement("DateUploaded").Value.AsDateTime, photo.GetElement("Location").Value.ToString(), photo.GetElement("Keywords").Value.ToString(), photo.GetElement("Subject").Value.ToString(), photo.GetElement("User").Value.ToString(), photo.GetElement("IsPublic").Value.AsBoolean);
            }
            return null;
        }

        /// <summary>
        /// creates a temporary password
        /// </summary>
        /// <returns></returns>
        public static string SetTemporaryPassword(string email)
        {
            if (GetTemporaryPassword(email) != null)
            {
                DeleteTemporaryPassword(email);
            }

            Connect();

            var collection = dbDatabase.GetCollection<BsonDocument>("TemporaryPasswords");

            const string validChars = "1234567890";

            Random random = new Random();
            StringBuilder password = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                int randomIndex = random.Next(validChars.Length);
                password.Append(validChars[randomIndex]);
            }


            BsonDocument newPass = new BsonDocument { {"Email", email },
                    {"Password", BCrypt.Net.BCrypt.HashPassword(password.ToString()) }};
            collection.InsertOne(newPass);

            return password.ToString();
        }

        /// <summary>
        /// deletes temp password
        /// </summary>
        /// <param name="email"></param>
        public static void DeleteTemporaryPassword(string email)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);

            var collection = dbDatabase.GetCollection<BsonDocument>("TemporaryPasswords");

            collection.DeleteOne(filter);
        }

        /// <summary>
        /// gets temporary password
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static string GetTemporaryPassword(string email)
        {
            Connect();

            var filter = Builders<BsonDocument>.Filter.Eq("Email", email);

            var collection = dbDatabase.GetCollection<BsonDocument>("TemporaryPasswords");

            var passwords = collection.Find(filter).ToList();

            if (passwords.Count > 0)
            {
                return passwords[0].GetElement("Password").Value.ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
