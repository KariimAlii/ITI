using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarAppTests
{
    [TestClass]
    public class CarStoreTests
    {

        [TestMethod]
        public void GetStoreCars_ToyotaCars_SameType()
        {
            // Arrange
            var car1 = new Toyota();
            var car2 = new Toyota();
            var car3 = new Toyota();
            var car4 = new Toyota();

            var carStore = new CarStore(new List<Car>() { car1, car2, car3, car4 });

            // Act
            var cars = carStore.GetStoreCars();

            // Assert
            CollectionAssert.AllItemsAreInstancesOfType(cars, typeof(Toyota));
        }

        [TestMethod]
        public void GetStoreCars_DifferentInstances_Unique()
        {
            // Arrange
            var car1 = new Audi();
            var car2 = new Audi();
            var car3 = new Audi();
            var car4 = new Audi();

            var carStore = new CarStore(new List<Car>() { car1, car2, car3, car4 });
            // Act
            var cars = carStore.GetStoreCars();
            // Assert
            CollectionAssert.AllItemsAreUnique(cars); // ==> checks for references of different instances
        }

        [TestMethod]
        public void GetStoreCars_EqualCarsSameOrder_Equal()
        {
            // Arrange
            var car1 = new Toyota(50, DrivingMode.Forward);
            var car2 = new Toyota(80, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car>() { car1 , car2});

            var car3 = new Toyota(50, DrivingMode.Forward);
            var car4 = new Toyota(80, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car>() { car3 , car4 }); // same order ==> success (same order)

            // Act
            var cars1 = carStore1.GetStoreCars();
            var cars2 = carStore2.GetStoreCars();

            // Assert
            CollectionAssert.AreEqual(cars1, cars2);

            // CollectionAssert.AreEqual
            // 1- compares references unless you overload the Equals() method
            // 2- compares items in order
        }

        [TestMethod]
        public void GetStoreCars_EqualCarsDifferentOrder_NotEqual()
        {
            // Arrange
            var car1 = new Toyota(50, DrivingMode.Forward);
            var car2 = new Toyota(80, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car>() { car1, car2 });

            var car3 = new Toyota(50, DrivingMode.Forward);
            var car4 = new Toyota(80, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car>() { car4, car3 }); // different order ==> success (different order)

            // Act
            var cars1 = carStore1.GetStoreCars();
            var cars2 = carStore2.GetStoreCars();

            // Assert
            CollectionAssert.AreNotEqual(cars1, cars2);

            // CollectionAssert.AreNotEqual
            // 1- compares references unless you overload the Equals() method
            // 2- compares items in order
        }

        [TestMethod]
        public void GetStoreCars_SameCarsSameOrder_Equivalent()
        {
            // Arrange
            var car1 = new Toyota(50, DrivingMode.Forward);
            var car2 = new Toyota(80, DrivingMode.Reverse);

            var carStore1 = new CarStore(new List<Car>() { car1, car2 });
            var carStore2 = new CarStore(new List<Car>() { car1, car2 });

            // Act
            var cars1 = carStore1.GetStoreCars();
            var cars2 = carStore2.GetStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(cars1, cars2);

            // CollectionAssert.AreEquivalent
            // 1- compares references 
            // 2- doesnot compare items in order
        }

        [TestMethod]
        public void GetStoreCars_SameCarsDifferentOrder_Equivalent()
        {
            // Arrange
            var car1 = new Toyota(50, DrivingMode.Forward);
            var car2 = new Toyota(80, DrivingMode.Reverse);

            var carStore1 = new CarStore(new List<Car>() { car1, car2 });
            var carStore2 = new CarStore(new List<Car>() { car2, car1 });

            // Act
            var cars1 = carStore1.GetStoreCars();
            var cars2 = carStore2.GetStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(cars1, cars2);

            // CollectionAssert.AreEquivalent
            // 1- compares references 
            // 2- doesnot compare items in order
        }


        [TestMethod]
        public void GetStoreCars_EqualDifferentInstancesSameOrder_NotEquivalent()
        {
            // Arrange
            var car1 = new Toyota(50, DrivingMode.Forward);
            var car2 = new Toyota(80, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car>() { car1, car2 });

            var car3 = new Toyota(50, DrivingMode.Forward);
            var car4 = new Toyota(80, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car>() { car3, car4 }); // ===> same order

            // Act
            var cars1 = carStore1.GetStoreCars();
            var cars2 = carStore2.GetStoreCars();

            // Assert
            CollectionAssert.AreNotEquivalent(cars1, cars2);

            // CollectionAssert.AreEquivalent
            // 1- compares references 
            // 2- doesnot compare items in order
        }
        [TestMethod]
        public void GetStoreCars_EqualDifferentInstancesDifferentOrder_NotEquivalent()
        {
            // Arrange
            var car1 = new Toyota(50, DrivingMode.Forward);
            var car2 = new Toyota(80, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car>() { car1, car2 });

            var car3 = new Toyota(50, DrivingMode.Forward);
            var car4 = new Toyota(80, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car>() { car3, car4 }); // ===> different order

            // Act
            var cars1 = carStore1.GetStoreCars();
            var cars2 = carStore2.GetStoreCars();

            // Assert
            CollectionAssert.AreNotEquivalent(cars1, cars2);

            // CollectionAssert.AreEquivalent
            // 1- compares references 
            // 2- doesnot compare items in order
        }
        // Note
        //======
        // Equal ---> values
        // Same ---> values & reference
    }
}
