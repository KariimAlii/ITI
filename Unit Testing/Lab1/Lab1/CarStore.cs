using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class CarStore
    {
        #region Fields
        public List<Car> Cars { get; set; }
        #endregion

        #region Constructor
        public CarStore()
        {
            Cars = new List<Car>();
        }
        public CarStore(List<Car> cars)
        {
            Cars = cars;
        }
        #endregion

        #region Methods
        public List<Car> GetStoreCars() => Cars;
        public void AddCar(Car car)
        {
            Cars.Add(car);
        }
        public void AddCars(List<Car> cars)
        {
            Cars.AddRange(cars);
        }
        #endregion

    }
}
