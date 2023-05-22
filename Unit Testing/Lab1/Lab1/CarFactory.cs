using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public static class CarFactory
    {
        public static Car MakeCar(string type)
        {
            switch (type)
            {
                case "Audi":
                    return new Audi();
                case "Toyota":
                    return new Toyota();
                default:
                    throw new NotImplementedException();

            }
        }
    }
}
