namespace CarManager.Tests
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using NUnit.Framework;
    using System;
    using System.Reflection.Emit;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        private string validMake = "Make";
        private string validModel = "Model";
        private double validFuelConsumption = 10;
        private double validFuelCapacity = 100;

        [SetUp]
        public void SetUp()
        {
            car = new Car(validMake, validModel, validFuelConsumption, validFuelCapacity);
        }

        //--------------------------------------------------------------
        //Constructor tests
        [Test]
        public void Test_Constructor_SetsFuelAmountCorrectly()
        {
            Assert.AreEqual(0, car.FuelAmount,
                "Constructor doesn't set FuelAmount correctly.");
        }
        [Test]
        public void Test_Constructor_SetsMakeCorrectly()
        {
            Assert.AreEqual(validMake, car.Make,
                "Constructor doesn't set Make correctly.");
        }
        [Test]
        public void Test_Constructor_SetsModelCorrectly()
        {
            Assert.AreEqual(validModel, car.Model,
                "Constructor doesn't set Make correctly.");
        }
        [Test]
        public void Test_Constructor_SetsFuelConsumptionCorrectly()
        {
            Assert.AreEqual(validFuelConsumption, car.FuelConsumption,
                "Constructor doesn't set FuelConsumption correctly.");
        }
        [Test]
        public void Test_Constructor_SetsFuelCapacityCorrectly()
        {
            Assert.AreEqual(validFuelCapacity, car.FuelCapacity,
                "Constructor doesn't set FuelCapacity correctly.");
        }

        //--------------------------------------------------------------
        //Make setter tests
        [Test]
        public void Test_MakeSetter_SetsValueCorrectly()
        {
            Assert.AreEqual(validMake, car.Make,
                "Make setter doesn't set Make correctly.");
        }
        [Test]
        public void Test_MakeSetter_ThrowsWhenValueIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(null, validModel, validFuelConsumption, validFuelCapacity);
            }, "Make setter doesn't throw when Make parameter is null.");
        }
        [Test]
        public void Test_MakeSetter_ThrowsWhenValueIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car("", validModel, validFuelConsumption, validFuelCapacity);
            }, "Make setter doesn't throw when Make parameter is empty.");
        }

        //Make getter tests
        [Test]
        public void Test_MakeGetter_ReturnsValueCorrectly()
        {
            Assert.AreEqual(validMake, car.Make,
                "Make getter doesn't return Make value correctly.");
        }

        //--------------------------------------------------------------
        //Model setter tests
        [Test]
        public void Test_ModelSetter_SetsValueCorrectly()
        {
            Assert.AreEqual(validModel, car.Model,
                "Model setter doesn't set Model correctly.");
        }
        [Test]
        public void Test_ModelSetter_ThrowsWhenValueIsNull()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(validMake, null, validFuelConsumption, validFuelCapacity);
            }, "Model setter doesn't throw when Model parameter is null.");
        }
        [Test]
        public void Test_ModelSetter_ThrowsWhenValueIsEmpty()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(validMake, "", validFuelConsumption, validFuelCapacity);
            }, "Model setter doesn't throw when Model parameter is empty.");
        }

        //Model getter tests
        [Test]
        public void Test_ModelGetter_ReturnsValueCorrectly()
        {
            Assert.AreEqual(validModel, car.Model,
                "Model getter doesn't return Model value correctly.");
        }

        //--------------------------------------------------------------
        //FuelConsumption setter tests
        [Test]
        public void Test_FuelConsumptionSetter_SetsValueCorrectly()
        {
            Assert.AreEqual(validFuelConsumption, car.FuelConsumption,
                "FuelConsumption setter doesn't set FuelConsumption correctly.");
        }
        [Test]
        public void Test_FuelConsumptionSetter_ThrowsWhenValueIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(validMake, validModel, 0, validFuelCapacity);
            }, "FuelConsumption setter doesn't throw when FuelConsumption parameter is zero.");
        }
        [Test]
        public void Test_FuelConsumptionSetter_ThrowsWhenValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(validMake, validModel, -1, validFuelCapacity);
            }, "FuelConsumption setter doesn't throw when FuelConsumption parameter is less than zero.");
        }

        //FuelConsumption getter tests
        [Test]
        public void Test_FuelConsumptionGetter_ReturnsValueCorrectly()
        {
            Assert.AreEqual(validFuelConsumption, car.FuelConsumption,
                "FuelConsumption getter doesn't return FuelConsumption value correctly.");
        }

        //--------------------------------------------------------------
        //FuelAmount setter tests
        [Test]
        public void Test_FuelAmountSetter_SetsValueCorrectly()
        {
            Assert.AreEqual(0, car.FuelAmount,
                "FuelAmount setter doesn't set FuelAmount correctly.");
        }

        //FuelAmount getter tests
        [Test]
        public void Test_FuelAmountGetter_ReturnsValueCorrectly()
        {
            Assert.AreEqual(validFuelConsumption, car.FuelConsumption,
                "FuelAmount getter doesn't return FuelAmount value correctly.");
        }

        //--------------------------------------------------------------
        //FuelCapacity setter tests
        [Test]
        public void Test_FuelCapacitySetter_SetsValueCorrectly()
        {
            Assert.AreEqual(validFuelCapacity, car.FuelCapacity,
                "FuelCapacity setter doesn't set FuelCapacity correctly.");
        }
        [Test]
        public void Test_FuelCapacitySetter_ThrowsWhenValueIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(validMake, validModel, validFuelConsumption, 0);
            }, "FuelCapacity setter doesn't throw when FuelCapacity parameter is zero.");
        }
        [Test]
        public void Test_FuelCapacitySetter_ThrowsWhenValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car = new Car(validMake, validModel, validFuelCapacity, -1);
            }, "FuelCapacity setter doesn't throw when FuelCapacity parameter is less than zero.");
        }

        //FuelCapacity getter tests
        [Test]
        public void Test_FuelCapacityGetter_ReturnsValueCorrectly()
        {
            Assert.AreEqual(validFuelCapacity, car.FuelCapacity,
                "FuelCapacity getter doesn't return FuelCapacity value correctly.");
        }

        //--------------------------------------------------------------
        //Refuel method tests
        [Test]
        public void Test_Refuel_WorksCorrectlyWithValidData()
        {
            double refuelAmount = car.FuelCapacity / 2;
            double expectedFuelAmount = car.FuelAmount + refuelAmount;

            car.Refuel(refuelAmount);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount,
                "Refuel method doesn't work correctly with valid data.");
        }
        [Test]
        public void Test_Refuel_CannotOverfill()
        {
            car.Refuel(car.FuelCapacity * 2);

            Assert.AreEqual(car.FuelCapacity, car.FuelAmount,
                "Refuel method overfills the car.");
        }
        [Test]
        public void Test_Refuel_ThrowsWhenValueIsZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(0);
            }, "Refuel method doesn't throw when value is zero.");
        }
        [Test]
        public void Test_Refuel_ThrowsWhenValueIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(-1);
            }, "Refuel method doesn't throw when value is less than zero.");
        }

        //--------------------------------------------------------------
        //Refuel method tests
        [Test]
        public void Test_Drive_WorksCorrectlyWithValidData()
        {
            double refuelAmount = car.FuelCapacity / 2;
            car.Refuel(refuelAmount);
            double driveDistance = 250;
            double expectedFuelAmount = car.FuelAmount - (driveDistance / 100) * car.FuelConsumption;

            car.Drive(driveDistance);

            Assert.AreEqual(expectedFuelAmount, car.FuelAmount,
                "Drive method doesn't work correctly with valid data.");
        }
        [Test]
        public void Test_Drive_ThrowsWhenFuelAmountIsNotEnough()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(100);
            });
        }
    }
}