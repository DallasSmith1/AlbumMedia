using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMedia.Classes
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() { }
        public  UserAlreadyExistsException(string message) : base(message) { }
        public UserAlreadyExistsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
