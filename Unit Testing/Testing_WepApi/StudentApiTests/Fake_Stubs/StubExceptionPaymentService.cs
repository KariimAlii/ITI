using StudentApi.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApiTests.Fake_Stubs
{
    public class StubExceptionPaymentService : IPaymentService
    {
        public string Pay(double amount)
        {
            throw new NotImplementedException();
        }
    }
}
