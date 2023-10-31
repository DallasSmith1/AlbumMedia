using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AlbumMedia
{
    public class Movie
    {
        public Movie( string title, string description, string fileName, string posterURL, string releaseYear, string company) 
        {
            Title = title;
            Description = description;
            File = fileName;
            ReleaseYear = releaseYear;
            Company = company;
            Poster = posterURL;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string File { get; set; }
        public string Poster { get; set; }
        public string ReleaseYear { get; set; }
        public string Company { get; set; }

        /// <summary>
        /// gest the poser bitmpa image
        /// </summary>
        /// <returns></returns>
        public BitmapImage GetPosterBitMap()
        {
            return new BitmapImage(new Uri(Properties.Settings.Default.POSTERFOLDER+"\\"+Poster));
        }

        /// <summary>
        /// gets the Uri 
        /// </summary>
        /// <returns></returns>
        public Uri GetFileUri()
        {
            return new Uri(Properties.Settings.Default.MOVIEFOLDER+"\\"+File);
        }
    }
}