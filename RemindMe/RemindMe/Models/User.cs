using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemindMe.Models
{
    public class User
    {
      
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string CreateDate { get; set; }


        public int UserId { get; set; }
        private static int nextId = 1;

        //default constructor
        public User()
        {
            UserId = nextId;
            nextId++;
            CreateDate = DateTime.Today.ToString("MM/dd/yyyy");
            
        }
        
        //non default constructor
        public User(string username, string email, string password) : this()
        {
            Username = username;
            Email = email;
            Password = password;

        }





    }
}
