using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentApi.Payment
{
    public class CreditCardService : IPaymentService
    {
        public string Pay(double amount)
        {
            return $"{amount} is paid through credit card";
        }
    }
}