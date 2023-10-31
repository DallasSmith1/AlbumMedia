using AlbumMedia.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlbumMedia
{
    /// <summary>
    /// Interaction logic for Layout.xaml
    /// </summary>
    public partial class Layout : Page
    {
        public delegate void Hide();

        public static event Hide Hidden;

        public delegate void Appear();

        public static event Appear Appeared;

        public delegate void Email();

        public static event Email Emailed;

        public delegate void SetNewPassword(string username);

        public static event SetNewPassword OnSetNewPassword;
        public Layout()
        {
            InitializeComponent();
            SetPage("Home");
        }

        #region Variables
        string currentPage = string.Empty;
        User CurrentUser = null;
        double previousScrollPosition = 0;
        Movie selectedMovie = null;
        MovieGenre selectedMovieGenre = null;
        #endregion

        #region Home Page Events
        /// <summary>
        /// when the profile button is clicked
        /// </summary>
        private void Home_ProfileClicked()
        {
            SetPage("Profile");
        }

        /// <summary>
        /// when the shared button is clicked
        /// </summary>
        private void Home_SharedClicked()
        {
            SetPage("Shared");
        }

        /// <summary>
        /// when the photos button is clicked
        /// </summary>
        private void Home_PhotosClicked()
        {
            SetPage("Photos");
        }

        /// <summary>
        /// when the movie button is clicked
        /// </summary>
        private void Home_MovieClicked()
        {
            SetPage("Movie");
        }
        #endregion

        #region Login page events
        /// <summary>
        /// when the isLoggedIn function is called in the loginpage
        /// </summary>
        /// <param name="user"></param>
        private void Login_isLoggedIn(User user)
        {
            LoginUser(user);
            SetPage("Home");
        }

        private void Login_isResetPassword()
        {
            Emailed();
        }

        private void Login_isTemporaryPassword(string username)
        {
            OnSetNewPassword(username);
        }
        #endregion

        #region Profile Events
        /// <summary>
        /// when the admin user clicks edit movies
        /// </summary>
        private void Profile_MovieEditClicked()
        {
            SetPage("MovieGenreEdit");
        }

        /// <summary>
        /// when user deletes ther account
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Profile_OnDeleteAccount()
        {
            LogoutUser();
            SetPage("Login");
        }
        #endregion

        #region Movie Player Events
        private void FullScreen_ClosedMovie()
        {
            Appeared();
        }

        #endregion

        #region Movie Events
        /// <summary>
        /// when a movie was sleected to play
        /// </summary>
        private void Movies_PlayedMovie(Movie movie)
        {
            selectedMovie = movie;
            SetPage("MoviePlayer");
        }

        /// <summary>
        /// when a movie was searched
        /// </summary>
        private void Movies_SearchedAllMovies()
        {
            UIElementCollection elements = pnlLeftNav.Children;

            foreach (UIElement element in elements)
            {
                try
                {
                    Button button = (Button)element;
                    if ((string)button.Content == "Search")
                    {
                        Movies_RefreshSideNavBar(button);
                    }
                }
                catch { }
            }
        }


        /// <summary>
        /// when the user opens the details of a movie
        /// </summary>
        /// <param name="open"></param>
        private void Movies_OpenedDetails(bool open)
        {
            if (open)
            {
                previousScrollPosition = scrLayout.VerticalOffset;
                scrLayout.ScrollToTop();
                scrLayout.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
            }
            else
            {
                scrLayout.ScrollToVerticalOffset(previousScrollPosition);
                scrLayout.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
        }
        #endregion

        #region Movie Editor Events
        /// <summary>
        /// when the user selects a movie to edit
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="movieGenre"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void MovieGenreEdit_MovieEditorClicked(Movie movie, MovieGenre movieGenre)
        {
            selectedMovie = movie;
            selectedMovieGenre = movieGenre;

            SetPage("MovieEditor");
        }

        /// <summary>
        /// go back to the movie list from the editor page
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void MovieEdit__GoBack()
        {
            SetPage("MovieGenreEdit");
        }

        /// <summary>
        /// when add movie is clicked
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void MovieGenreEdit_MovieAddClicked()
        {
            SetPage("MovieAdd");
        }

        /// <summary>
        /// when movie adding was canceled
        /// </summary>
        private void MovieAdd_Canceled()
        {
            SetPage("MovieGenreEdit");
        }
        #endregion

        #region Photos Events
        /// <summary>
        /// when upload button is clicked
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void Photos_UploadPhotos()
        {
            SetPage("PhotoUpload");
        }

        private void PhotoUpload__GoBack()
        {
            SetPage("Photos");
        }



        #endregion

        #region Events
        /// <summary>
        /// when the login/logout button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLog_Click(object sender, RoutedEventArgs e)
        {
            if(CurrentUser == null)
            {
                SetPage("Login");
            }
            else
            {
                LogoutUser();
                SetPage("Home");
            }
        }

        /// <summary>
        /// when the profile is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            SetPage("Profile");
        }

        /// <summary>
        /// when the shared button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShared_Click(object sender, RoutedEventArgs e)
        {
            SetPage("Shared");
        }
        /// <summary>
        /// when the photos button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhotos_Click(object sender, RoutedEventArgs e)
        {
            SetPage("Photos");
        }
        /// <summary>
        /// when the movies button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMovies_Click(object sender, RoutedEventArgs e)
        {
            SetPage("Movie");
        }
        /// <summary>
        /// if the logo is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgLogo_Click(object sender, MouseButtonEventArgs e)
        {
            SetPage("Home");
        }

        /// <summary>
        /// when the user clicks one of the side bar buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SideNavBar_Click(object sender, RoutedEventArgs e)
        {
            ResourceDictionary Buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));

            Button button = sender as Button;

            button.Style = (Style)Buttons["TransparentSideActive"];

            bool performed;

            if ((string)button.Content == "Search")
            {
                Movies pages = (Movies)frmMain.NavigationService.Content;
                performed = pages.SearchMovies("");
            }
            else if((string)button.Content == "All")
            {
                Movies pages = (Movies)frmMain.NavigationService.Content;
                performed = pages.DisplayAllMovies();
            }
            else if ((string)button.Content == "Sci-Fi")
            {
                Movies pages = (Movies)frmMain.NavigationService.Content;
                performed = pages.OpenGenre("ScienceFiction");
            }
            else if ((string)button.Content == "Upload")
            {
                SetPage("PhotoUpload");
                return;
            }
            else if ((string)button.Content == "Select")
            {
                Photos pages = (Photos)frmMain.NavigationService.Content;
                button.Style = (Style)Buttons["TransparentSideActive"];

                ToggleSelection(pages.ToggleSelection());
                return;
            }
            else
            {
                Movies pages = (Movies)frmMain.NavigationService.Content;
                performed = pages.OpenGenre(button.Content.ToString().Replace(" ", ""));
            }

            if (performed)
            {
                Movies_RefreshSideNavBar(button);
            }
            else
            {
                //Movies_RefreshSideNavBar(Movies_GetActiveButton());
                Movies_RefreshSideNavBar(button);
            }

            scrLayout.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
        }

        /// <summary>
        /// when user clicks continue with selected files
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectContinue_Click(object sender, RoutedEventArgs e)
        {
            SetPage("SelectedPhotos");
        }

        /// <summary>
        /// when selected photos is canceld
        /// </summary>
        private void FileInteractivity_Canceled()
        {
            SetPage("Photos");
        }
        #endregion

        #region Custom Functions
        /// <summary>
        /// sets the current page in the frame
        /// </summary>
        /// <param name="page"></param>
        private void SetPage(string page) 
        {
            for (int i = 0; i < grdFrame.Children.Count; i++)
            {
                try
                {
                    Button button = (Button)grdFrame.Children[i];
                    grdFrame.Children.RemoveAt(i);
                    break;
                }
                catch
                {

                }
            }

            //frmMain.NavigationService.RemoveBackEntry();
            //frmMain.NavigationService.Refresh();

            if (currentPage != page)
            {
                if (page == "Home")
                {
                    Home.MovieClicked += Home_MovieClicked;
                    Home.PhotosClicked += Home_PhotosClicked;
                    Home.SharedClicked += Home_SharedClicked;
                    Home.ProfileClicked += Home_ProfileClicked;
                    Home home = new Home();
                    home.HorizontalAlignment = HorizontalAlignment.Center;
                    home.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(home);
                }
                else if (page == "Login")
                {
                    Login.isLoggedIn += Login_isLoggedIn;
                    Login.isResetPassword += Login_isResetPassword;
                    Login.isTemporaryPassword += Login_isTemporaryPassword;
                    Login login = new Login();
                    login.HorizontalAlignment = HorizontalAlignment.Center;
                    login.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(login);
                }
                else if (page == "Profile")
                {
                    if (CurrentUser == null)
                    {
                        SetPage("Login");
                        page = "Login";
                    }
                    else
                    {
                        Profile.MovieEditClicked += Profile_MovieEditClicked;
                        Profile.OnDeleteAccount += Profile_OnDeleteAccount;
                        Profile profile = new Profile(CurrentUser);
                        profile.HorizontalAlignment = HorizontalAlignment.Center;
                        profile.VerticalAlignment = VerticalAlignment.Center;
                        frmMain.NavigationService.Navigate(profile);
                    }
                }
                else if (page == "Shared")
                {
                    if (CurrentUser == null)
                    {
                        SetPage("Login");
                        page = "Login";
                    }
                    else
                    {
                        PhotosShared shared = new PhotosShared();
                        shared.HorizontalAlignment = HorizontalAlignment.Center;
                        shared.VerticalAlignment = VerticalAlignment.Center;
                        frmMain.NavigationService.Navigate(shared);
                    }
                }
                else if (page == "Photos")
                {
                    if (CurrentUser == null)
                    {
                        SetPage("Login");
                        page = "Login";
                    }
                    else
                    {
                        Photos.UploadPhotos += Photos_UploadPhotos;
                        Photos newPage = new Photos(CurrentUser);
                        newPage.HorizontalAlignment = HorizontalAlignment.Center;
                        newPage.VerticalAlignment = VerticalAlignment.Center;
                        frmMain.NavigationService.Navigate(newPage);
                    }
                }
                else if (page == "Movie")
                {
                    Movies.SearchedAllMovies += Movies_SearchedAllMovies;
                    Movies.PlayedMovie += Movies_PlayedMovie;
                    Movies.OpenedDetails += Movies_OpenedDetails; ;
                    Movies moviesPage = new Movies();
                    moviesPage.HorizontalAlignment = HorizontalAlignment.Center;
                    moviesPage.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(moviesPage);
                }
                else if (page == "MovieGenreEdit")
                {
                    MovieGenreEdit.MovieEditorClicked += MovieGenreEdit_MovieEditorClicked;
                    MovieGenreEdit.MovieAddClicked += MovieGenreEdit_MovieAddClicked;
                    MovieGenreEdit newPage = new MovieGenreEdit();
                    newPage.HorizontalAlignment = HorizontalAlignment.Center;
                    newPage.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(newPage);
                }
                else if (page == "MovieEditor")
                {
                    MovieEdit._GoBack += MovieEdit__GoBack;
                    MovieEdit newPage = new MovieEdit(selectedMovie, selectedMovieGenre);
                    newPage.HorizontalAlignment = HorizontalAlignment.Center;
                    newPage.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(newPage);
                }
                else if (page == "MoviePlayer")
                {
                    FullScreen.ClosedMovie += FullScreen_ClosedMovie;
                    FullScreen newPage = new FullScreen(new MoviePlayer(selectedMovie));
                    newPage.Show();
                    Hidden();
                    page = string.Empty;
                }
                else if (page == "MovieAdd")
                {
                    MovieAdd.Canceled += MovieAdd_Canceled;
                    MovieAdd newPage = new MovieAdd();
                    newPage.HorizontalAlignment = HorizontalAlignment.Center;
                    newPage.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(newPage);
                }
                else if (page == "PhotoUpload")
                {
                    PhotoUpload._GoBack += PhotoUpload__GoBack;
                    PhotoUpload newPage = new PhotoUpload(CurrentUser);
                    newPage.HorizontalAlignment = HorizontalAlignment.Center;
                    newPage.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(newPage);
                }
                else if (page == "SelectedPhotos")
                {
                    Photos currentPage = (Photos)frmMain.NavigationService.Content;
                    FileInteractivity.Canceled += FileInteractivity_Canceled;
                    FileInteractivity newPage = new FileInteractivity(currentPage.selectedPhotos, CurrentUser.Username);
                    newPage.HorizontalAlignment = HorizontalAlignment.Center;
                    newPage.VerticalAlignment = VerticalAlignment.Center;
                    frmMain.NavigationService.Navigate(newPage);
                }
                SetLeftNavValues(page);
                currentPage = page;
            }
        }

        













        /// <summary>
        /// sets the navbar values
        /// </summary>
        /// <param name="page"></param>
        private void SetLeftNavValues(string page)
        {
            if (page != string.Empty)
            {
                pnlLeftNav.Children.Clear();
                ResourceDictionary Labels = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\LabelDictionary.xaml", UriKind.Relative));
                ResourceDictionary Expanders = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ExpanderDictionary.xaml", UriKind.Relative));
                if (page == "Home")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = page;
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "Login")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = page;
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "Profile")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = page;
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "MovieGenreEdit")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = "Movie Editor";
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "Movie")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = "Movies";
                    pnlLeftNav.Children.Add(title);
                
                    pnlLeftNav.Children.Add(CreateSideBarButton("Search", false));
                    pnlLeftNav.Children.Add(CreateSideBarButton("All", true));
                
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

                    Expander expander = new Expander();
                    expander.Style = (Style)Expanders["LeftNavExpander"];
                    expander.Content = "Genres";

                    stackPanel.Children.Add(CreateSideBarButton("Action", false));
                    stackPanel.Children.Add(CreateSideBarButton("Adult", false));
                    stackPanel.Children.Add(CreateSideBarButton("Adventure", false));
                    stackPanel.Children.Add(CreateSideBarButton("Animated", false));
                    stackPanel.Children.Add(CreateSideBarButton("Comedy", false));
                    stackPanel.Children.Add(CreateSideBarButton("Disney", false));
                    stackPanel.Children.Add(CreateSideBarButton("Drama", false));
                    stackPanel.Children.Add(CreateSideBarButton("Horror", false));
                    stackPanel.Children.Add(CreateSideBarButton("Jurassic", false));
                    stackPanel.Children.Add(CreateSideBarButton("Kids", false));
                    stackPanel.Children.Add(CreateSideBarButton("Romance", false));
                    stackPanel.Children.Add(CreateSideBarButton("Sci-Fi", false));
                    stackPanel.Children.Add(CreateSideBarButton("Star Wars", false));
                    stackPanel.Children.Add(CreateSideBarButton("Super Hero", false));
                    stackPanel.Children.Add(CreateSideBarButton("Thriller", false));

                    expander.Content = stackPanel;

                    pnlLeftNav.Children.Add(expander);
                }
                else if (page == "MovieEditor")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = "Movie Editor";
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "MoviePlayer")
                {
                
                }
                else if (page == "MovieAdd")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = "Add A Movie!";
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "Photos")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = page;
                    pnlLeftNav.Children.Add(title);
                    pnlLeftNav.Children.Add(CreateSideBarButton("Upload", false));
                    pnlLeftNav.Children.Add(CreateSideBarButton("Select", false));
                }
                else if (page == "PhotoUpload")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = page;
                    pnlLeftNav.Children.Add(title);
                }
                else if (page == "Shared")
                {
                    Label title = new Label();
                    title.Style = (Style)Labels["Title"];
                    title.Content = page;
                    pnlLeftNav.Children.Add(title);
                }
            }
        }

        /// <summary>
        /// logs the user in
        /// </summary>
        /// <param name="user"></param>
        private void LoginUser(User user)
        {
            CurrentUser = user;
            lblLoggedInUser.Content = user.Username;
            btnLog.Content = "Logout";
        }

        /// <summary>
        /// logs the user out
        /// </summary>
        private void LogoutUser() 
        {
            CurrentUser = null;
            lblLoggedInUser.Content = string.Empty;
            btnLog.Content = "Login";
            SetPage("Home");
        }

        /// <summary>
        /// creates a button for the side bar
        /// </summary>
        /// <param name="content"></param>
        /// <param name="isActive"></param>
        private Button CreateSideBarButton(string content, bool isActive)
        {
            ResourceDictionary Buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
            Button newButton = new Button();
            newButton.Content = content;
            if (isActive)
            {
                newButton.Style = (Style)Buttons["TransparentSideActive"];
            }
            else
            {
                newButton.Style = (Style)Buttons["TransparentSide"];
            }
            newButton.Click += SideNavBar_Click;
            return newButton;
        }


        /// <summary>
        /// updates the side nav bar highlighting the category
        /// </summary>
        private void Movies_RefreshSideNavBar(Button buttonSwap)
        {
            
            ResourceDictionary Buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
            
            UIElementCollection elements = pnlLeftNav.Children;

            for (int i = 0; i < elements.Count; i++)
            {
                if (elements[i] == buttonSwap)
                {
                    elements[i] = buttonSwap;
                }
                else
                {
                    try
                    {
                        Button swap = (Button)elements[i];
                        swap.Style = (Style)Buttons["TransparentSide"];
                        elements[i] = swap;
                    }
                    catch
                    {
                        try
                        {
                            UIElementCollection subElements = ((StackPanel)((Expander)elements[i]).Content).Children;

                            for (int j = 0; j < subElements.Count; j++)
                            {
                                Button swap = (Button)subElements[j];
                                swap.Style = (Style)Buttons["TransparentSide"];
                                subElements[j] = swap;
                            }
                        }
                        catch { }
                    }
                }
            }

            buttonSwap.Style = (Style)Buttons["TransparentSideActive"];

            scrLayout.ScrollToTop();
        }


        /// <summary>
        /// toggles continue button
        /// </summary>
        /// <param name="isOn"></param>
        private void ToggleSelection(bool isOn)
        {
            if (isOn)
            {
                ResourceDictionary Buttons = (ResourceDictionary)Application.LoadComponent(new Uri("\\ResourceDictionaries\\ButtonDictionary.xaml", UriKind.Relative));
                Button newButton = new Button();
                newButton.Style = (Style)Buttons["Modern"];
                newButton.Content = "Continue →";
                newButton.Height = 34;
                newButton.Width = 135;
                newButton.HorizontalAlignment = HorizontalAlignment.Center;
                newButton.VerticalAlignment = VerticalAlignment.Top;
                newButton.Click += SelectContinue_Click;

                grdFrame.Children.Add(newButton);
            }
            else
            {
                for (int i = 0; i < grdFrame.Children.Count; i++)
                {
                    try
                    {
                        Button button = (Button)grdFrame.Children[i];
                        if (button.Content.ToString() == "Continue →")
                        {
                            grdFrame.Children.RemoveAt(i);
                        }
                    }
                    catch { }
                }
                SetLeftNavValues("Photos");
            }
        }


        #endregion

    }

}
