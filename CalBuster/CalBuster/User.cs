using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalBuster
{
    public class User
    {
       public string userName { get; set; }
       public string password { get; set; }
       public int userId { get; set; }

       //default constructor
       public User()
       { }

        public User(string fN, string pwd)
        {
            userName = fN;
            password = pwd;
        }
    }
}