using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Payment
{
    internal interface IPaymentService
    {
        string Pay(double amount);
    }
}
