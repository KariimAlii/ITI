using System.ComponentModel.DataAnnotations;

namespace Lab1.Validators
{
    public class DateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
            => value is DateTime ProductionDate && ProductionDate < DateTime.Now;

        //public override bool IsValid(object value)
        //{
        //    DateTime? ProductionDate = value as DateTime?; // Null if casting failed
        //    if (ProductionDate is null) return false;
        //    if (ProductionDate < DateTime.Now)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
