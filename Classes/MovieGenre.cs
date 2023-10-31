using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace AlbumMedia.Classes
{
    public class MovieGenre
    {

        public MovieGenre(string movieTitle, bool horror, bool disney, bool comedy, bool animated, bool scifi, bool action, bool adventure, bool superHero, 
            bool starWars, bool jurassic, bool kids, bool adult, bool romance, bool drama, bool thriller) 
        { 
            MovieTitle = movieTitle;
            Horror = horror;
            Disney = disney;
            Comedy = comedy;
            Animated = animated;
            ScienceFiction = scifi;
            Action = action;
            Advanture = adventure;
            SuperHero = superHero;
            StarWars = starWars;
            Jurassic = jurassic;
            Kids = kids;
            Adult = adult;
            Romance = romance;
            Thriller = thriller;
            Drama = drama;
        }

        public string MovieTitle { get; set; }
        public bool Horror { get; set; }
        public bool Disney { get; set; }
        public bool Comedy { get; set; }
        public bool Animated { get; set; }
        public bool ScienceFiction { get; set; }
        public bool Action { get; set; }
        public bool Advanture { get; set; }
        public bool SuperHero { get; set; }
        public bool StarWars { get; set; }
        public bool Jurassic { get; set; }
        public bool Kids { get; set; }
        public bool Adult { get; set; }
        public bool Romance { get; set; }
        public bool Drama { get; set; }
        public bool Thriller { get; set; }
    }
}
