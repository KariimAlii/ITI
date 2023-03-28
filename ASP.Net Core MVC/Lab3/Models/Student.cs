using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;

namespace Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Name Length should be between 3 to 10 characters.")]
        public string Name { get; set; }
        [Range(0, 50)]
        public int Grade { get; set; }

        [MyEmailValidator(ErrorMessage = "This email doesnt match our email constrains")]
        public string Email { get; set; }

        [Required, StringLength(10, MinimumLength = 3)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string cPassword { get; set; }
    }
    class MyEmailValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string emailAddress = value.ToString();
            if (emailAddress.Contains('@')) return true;
            else return false;
        }
    }
    //class MyEmailValidator : ValidationAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        string emailAddress = value.ToString();
    //        try
    //        {
    //            MailAddress m = new MailAddress(emailAddress);
    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }
    //    }
    //    // https://uibakery.io/regex-library/email-regex-csharp
    //}

    //=======Email=======//
    //[RegularExpression(@"^\\S+@\\S+\\.\\S+$")]
    //[Remote("CheckEmail", "Student", AdditionalFields = "Name,Grade")]
}
