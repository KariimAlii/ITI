using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class RegistrationInput
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}