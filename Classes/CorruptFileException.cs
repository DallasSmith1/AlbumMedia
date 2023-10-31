using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMedia.Classes
{
    public class CorruptFileException : Exception
    {
        public CorruptFileException() { }
        public CorruptFileException(string message) : base(message) { }
        public CorruptFileException(string message, Exception innerException) : base(message, innerException) { }
    }
}
