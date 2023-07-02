using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Models
{
    public class BuyCourseInput
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int AmountPaid { get; set; }
        public PaymentMethod Method { get; set; }
    }

}