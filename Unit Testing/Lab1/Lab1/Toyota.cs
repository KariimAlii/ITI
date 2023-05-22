using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class Toyota : Car
    {
        public Toyota() : base("Toyota", 0, DrivingMode.Stopped)
        {
        }
        public Toyota(double velocity, DrivingMode drivingMode) : base("Toyota",velocity, drivingMode)
        {
        }

        public override void Accelerate()
        {
            Velocity += 10;
        }

        public override void Brake()
        {
            Velocity -= 10;
        }
    }
}
