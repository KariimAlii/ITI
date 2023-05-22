using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class Audi : Car
    {
        public Audi() : base("Audi", 0, DrivingMode.Stopped)
        {
        }

        public Audi(double velocity, DrivingMode drivingMode) : base("Audi", velocity, drivingMode)
        {
        }

        public override void Accelerate()
        {
            Velocity += 15;
        }
        public override void Brake()
        {
            Velocity -= 15;
        }
    }
}
