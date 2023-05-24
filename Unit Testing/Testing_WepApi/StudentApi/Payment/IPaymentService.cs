using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApi.Payment
{
    public interface IPaymentService
    {
        string Pay(double amount);
    }
}
