using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMedia.Classes
{
    public class TemporaryPasswordException : Exception
    {
        public TemporaryPasswordException() { }
        public TemporaryPasswordException(string message) { }
    }
}
