using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ComponentModel;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {
        // Naming Convention: "MethodName_StateUnderTest_ExpectedBehavior"


        #region Assert
        [TestCategory("Equality")]
        [Owner("Karim Ali")]
        [TestMethod]
        public void CalculateTime_Distance100Velocity50_ValidTime()
        {
            // Arrange
            var toyota = new Toyota();
            toyota.Velocity = 50;
            double distance = 100;

            double expectedResult = 2;

            // Act
            var actualResult = toyota.CalculateTime(distance);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }


        [TestCategory("Equality")]
        [Owner("Karim Ali")]
        [DataTestMethod]
        [DataRow(150, 50, 3)]
        [DataRow(400, 100, 4)]
        public void CalculateTime_ValidateDistanceForVelocity_ValidTime(double distance, double velocity, double expectedResult)
        {
            // Arrange

            var toyota = new Toyota();
            toyota.Velocity = velocity;

            // Act

            var actualResult = toyota.CalculateTime(distance);

            // Assert
            Assert.AreEqual(actualResult, expectedResult);
        }
        [TestCategory("Equality")]
        [Owner("Karim Ali")]
        [TestMethod]
        public void GetMyCar_DifferentInstancesSameState_EqualCars()
        {
            // Arrange

            var car1 = new Toyota();
            var car2 = new Toyota();

            // Act

            var firstCar = car1.GetMyCar();
            var secondCar = car2.GetMyCar();

            // Assert

            Assert.AreEqual(firstCar, secondCar);
            //Assert.AreNotEqual(firstCar, secondCar);
        }
        [TestCategory("Equality")]
        [Owner("Rana Youssef")]
        [TestMethod]
        public void GetMyCar_DifferentInstancesSameState_NotSameCars()
        {
            // Arrange

            var car1 = new Toyota();
            var car2 = new Toyota();

            // Act

            var firstCar = car1.GetMyCar();
            var secondCar = car2.GetMyCar();

            // Assert

            //Assert.AreSame(firstCar, secondCar);
            Assert.AreNotSame(firstCar, secondCar);
        }
        [TestCategory("Car Factory")]
        [Priority(0)]
        [TestMethod]
        public void MakeCar_TypeToyota_ReturnToyota()
        {
            // Arrange
            var type = "Toyota";
            //var type = "Audi";
            // Act
            var car = CarFactory.MakeCar(type);
            // Assert
            Assert.IsInstanceOfType(car, typeof(Toyota));
        }
        [TestCategory("Car Factory")]
        [Priority(1)]
        [TestMethod]
        public void MakeCar_TypeToyota_NotNull()
        {
            //Arrange
            var type = "Audi";
            //Act
            var car = CarFactory.MakeCar(type);
            //Asset
            Assert.IsNotNull(car);
        }
        [TestCategory("Car Velocity")]
        [Priority(1)]
        [TestMethod]
        public void Accelerate_Velocity0_Velocity15()
        {
            // Arrange
            var audi = new Audi();
            // Act
            audi.Accelerate();
            // Assert
            Assert.AreEqual(audi.Velocity, 15);
        }
        [TestCategory("Car Velocity")]
        [Priority(1)]
        [TestMethod]
        public void Brake_Velocity15_areEqual()
        {
            // Arrange
            var audi = new Audi(15, DrivingMode.Reverse);
            // Act
            audi.Brake();
            // Assert
            Assert.AreEqual(audi.Velocity, 0);
        }
        [TestCategory("Car Velocity")]
        [Priority(1)]
        [TestMethod]
        public void isStopped_Velocity0_True()
        {
            // Arrange
            var audi = new Audi(0, DrivingMode.Stopped);
            // Act
            var isStopped = audi.isStopped();
            // Assert
            Assert.IsTrue(isStopped);
        } 
        #endregion


        #region String Assert
        [TestCategory("String Assert")]
        [TestMethod]
        public void GetDirection_Reverse_Match()
        {
            // Arrange
            var audi = new Audi(7, DrivingMode.Reverse);

            // Act
            var direction = audi.GetDirection();
            // Assert
            StringAssert.Matches(direction, new System.Text.RegularExpressions.Regex("Reverse$"));
        }
        #endregion

        #region Exception
        [TestCategory("Check for Exception")]
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CalculateTime_Velocity0_ThrowException()
        {
            var audi = new Audi();
            audi.Velocity = 0;
            audi.CalculateTime(200);
        }

        [TestCategory("Check for Exception")]
        [TestMethod]
        public void CalculateTime_Velocity0_ThrowExceptionUsingLambdaExpression()
        {
            var audi = new Audi();
            audi.Velocity = 0;
            Assert.ThrowsException<Exception>(() => audi.CalculateTime(200));
        }
        #endregion
    }
}
