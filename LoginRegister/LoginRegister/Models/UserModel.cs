using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoginRegister.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Sector { get; set; }
        public string Legajo { get; set; }

    }
}
