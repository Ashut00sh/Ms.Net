using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment01.Models
{
    public class User
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
    }
}