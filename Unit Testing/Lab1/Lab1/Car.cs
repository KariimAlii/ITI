using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public abstract class Car
    {
        #region Fields
        public string Type { get; set; }
        public double Velocity { get; set; }
        public DrivingMode DrivingMode { get; set; }
        #endregion

        #region Contsructor
        public Car()
        {

        }

        public Car(string type, double velocity, DrivingMode drivingMode)
        {
            Type = type;
            Velocity = velocity;
            DrivingMode = drivingMode;
        }
        #endregion

        #region Methods
        public double CalculateTime(double distance)
        {
            if (Velocity == 0)
                throw new Exception("Cannot devide by Zero!!");
            return distance / Velocity;
        }
        public abstract void Accelerate();
        public abstract void Brake();
        public void Stop()
        {
            Velocity = 0;
        }

        public bool isStopped()
        {
            return (Velocity == 0);
        }
        public string GetDirection()
        {
            string direction;
            switch (DrivingMode)
            {
                case DrivingMode.Forward:
                    direction = "Forward";
                    break;
                case DrivingMode.Reverse:
                    direction = "Reverse";
                    break;
                case DrivingMode.Stopped:
                    direction = "Stopped";
                    break;
                default :
                    direction = String.Empty;
                    break;
            }
            return direction;
        }
        public Car GetMyCar()
        {
            return this;
        }
        #endregion

        #region Overriding Methods
        public override bool Equals(object obj)
        {
            Car car = obj as Car;
            return (car.Type == this.Type && car.Velocity == this.Velocity && car.DrivingMode == this.DrivingMode);
        }
        #endregion
    }

}
