using AlbumMedia.Classes;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MovieGenreEdit.xaml
    /// </summary>
    public partial class MovieGenreEdit : Page
    {
        public delegate void MovieEditorClick(Movie movie, MovieGenre movieGenre);

        public static event MovieEditorClick MovieEditorClicked;

        public delegate void MovieAddClick();

        public static event MovieAddClick MovieAddClicked;

        public MovieGenreEdit()
        {
            InitializeComponent();
            GetValues();
        }


        /// <summary>
        /// gets the list of movies and enters them into the datagrid
        /// </summary>
        private void GetValues()
        {
            dgrMovie.Items.Clear();

            dgrMovie.ItemsSource = MyMongoDB.GetMovieGenreList();
        }

        /// <summary>
        /// go to the editor page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoToEditPage(object sender, SelectionChangedEventArgs e)
        {
            MovieEditorClicked(MyMongoDB.GetMovie(((MovieGenre)dgrMovie.SelectedItem).MovieTitle), (MovieGenre)dgrMovie.SelectedItem);
        }

        /// <summary>
        /// when user clicks add movie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            MovieAddClicked();
        }
    }
}
