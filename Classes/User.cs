using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMedia
{
    public class User
    {
        public User(string id, string username, string password, bool isAdmin, string email) 
        {
            Id = id;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
            Email = email;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
            IsAdmin = false;
            Email = "";
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string RevealedPassword { get; set; }
        public string Email { get; set; }
    }
}
