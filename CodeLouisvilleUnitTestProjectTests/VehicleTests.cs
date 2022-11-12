using CodeLouisvilleUnitTestProject;
using FluentAssertions;
using FluentAssertions.Execution;
using System.Security.Cryptography.X509Certificates;
using Xunit.Abstractions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class VehicleTests
    {
       public object GasRemaining;
       public double GasTankCapacity;
        private string statusString;

        //Verify the parameterless constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to their default values.
        [Fact]
        public void VehicleParameterlessConstructorTest()
       {
            //arrange
            Vehicle vehicle = new Vehicle(0, 0, "", "", 0);
            Vehicle Vehicle = vehicle;
            //  act

            //assert
           Vehicle.Should().Be(Vehicle);
        }

        //Verify the parameterized constructor successfully creates a new
        //object of type Vehicle, and instantiates all public properties
        //to the provided values.
        [Fact]
        public void VehicleConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle(4, 10, "Ford", "F150", 20);
            var Vehicle = vehicle;
            //act

            //assert
           Vehicle.Should().Be(Vehicle);
        }

        //Verify that the parameterless AddGas method fills the gas tank
        //to 100% of its capacity
        [Fact]
        public void AddGasParameterlessFillsGasToMax( )
        {
            //arrange
            GasRemaining = GasTankCapacity;
            //act

            //assert
            GasTankCapacity.Should().Be((double)GasRemaining);
        }
        //Verify that the AddGas method with a parameter adds the
        //supplied amount of gas to the gas tank.
        [Fact]
        public void AddGasWithParameterAddsSuppliedAmountOfGas()
        {
         //arrange
            double amount = 5;
            double GasTankCapacity = 0;
            double GasRemaining =  GasTankCapacity - amount; ;
        //act
        double NewTotal = GasRemaining + amount;
        GasTankCapacity.Should().Be(NewTotal);
        }

        //Verify that the AddGas method with a parameter will throw
        //a GasOverfillException if too much gas is added to the tank.
        [Fact]
        public void AddingTooMuchGasThrowsGasOverflowException()
        {
            //arrange
            double GasTankCapacity = 10;
            double amount = 12;
            double GasRemaining = 5;
            double NewTotal = amount + GasRemaining;
            //act
            if (NewTotal > GasTankCapacity)
                throw GasOverfillException(amount, GasTankCapacity);
            //assert
            NewTotal.Should().Be(GasOverfillException, "becauise the tank only holds 10");
        }

        //Using a Theory (or data-driven test), verify that the GasLevel
        //property returns the correct percentage when the gas level is
        //at 0%, 25%, 50%, 75%, and 100%.
        [Theory]
        [InlineData("0%", 0)]
        [InlineData("25%", 2.5)]
        [InlineData("50%", 5)]
        [InlineData("75%", 7.5)]
        [InlineData("100%", 10)]

        public void GasLevelPercentageIsCorrectForAmountOfGas(string percent, int gasToAdd)
        {
            //arrange
           Vehicle vehicle = new Vehicle(4, 10, "Ford", "Junker", 20);

            //act
            vehicle.AddGas(gasToAdd);

            //assert
            vehicle.GasLevel.Should().Be(percent);
        }

        /*
         * Using a Theory (or data-driven test), or a combination of several 
         * individual Fact tests, test the following functionality of the 
         * Drive method:
         *      a. Attempting to drive a car without gas returns the status 
         *      string “Cannot drive, out of gas.”.
         *      b. Attempting to drive a car with a flat tire returns 
         *      the status string “Cannot drive due to flat tire.”.
         *      c. Drive the car 10 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled, 
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      d. Drive the car 100 miles. Verify that the correct amount 
         *      of gas was used, that the correct distance was traveled,
         *      that GasLevel is correct, that MilesRemaining is correct, 
         *      and that the total mileage on the vehicle is correct.
         *      e. Drive the car until it runs out of gas. Verify that the 
         *      correct amount of gas was used, that the correct distance 
         *      was traveled, that GasLevel is correct, that MilesRemaining
         *      is correct, and that the total mileage on the vehicle is 
         *      correct. Verify that the status reports the car is out of gas.
        */
        [Fact]
        public void Drivet()
        {
            //arrange
            miles = 0;
             statusString = "Cannot drive, out of gas.";
             //act     
             if(MilesRemaining == 0)
                  return "Cannot drive, out of gas.";
            //assert
           Vehicle.ableToDrive.Should().Be(statusString, "becausethe car is out of gas");
        }
        [Fact]
        public string Drive()
        {
            statusString = "Cannot drive due to flat tire.";
            //act     
            if (true)
                return "Cannot drive due to flat tire.";
            //assert
            Vehicle.ableToDrive.Should().Be(statusString, "because a tire is flat");
        }

        [Theory]
        [InlineData(10, .5)]
        [InlineData(100, 5)]
        [InlineData(200, 10)]
        public void DriveNegativeTests(int miles, double gasUsed)
        {
            //arrange
            int GasTankCapacity = 10;
            int MilesPerGallon = 20;
            int TotalMilesPerTank = MilesPerGallon * GasTankCapacity;
            double GasRemaining = GasTankCapacity - gasUsed;
            int MilesRemaining = (int)(GasRemaining / MilesPerGallon);

            //act
           // Vehicle.Drive(ableToDrive);

            //assert

            Vehicle.ableToDrive.Should().Be(miles, gasUsed, GasRemaining, MilesRemaining, TotalMilesPerTank );
        }

        [Theory]
        [InlineData("MysteryParamValue")]
        public void DrivePositiveTests(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that attempting to change a flat tire using
        //ChangeTireAsync will throw a NoTireToChangeException
        //if there is no flat tire.
        [Fact]
        public async Task ChangeTireWithoutFlatTest()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //Verify that ChangeTireAsync can successfully
        //be used to change a flat tire
        [Fact]
        public async Task ChangeTireSuccessfulTest()
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }

        //BONUS: Write a unit test that verifies that a flat
        //tire will occur after a certain number of miles.
        [Theory]
        [InlineData("MysteryParamValue")]
        public void GetFlatTireAfterCertainNumberOfMilesTest(params object[] yourParamsHere)
        {
            //arrange
            throw new NotImplementedException();
            //act

            //assert

        }
    }
}