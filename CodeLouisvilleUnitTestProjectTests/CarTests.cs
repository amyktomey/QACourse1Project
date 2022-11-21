using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeLouisvilleUnitTestProject;
using FluentAssertions;

namespace CodeLouisvilleUnitTestProjectTests
{
    public class CarTests
    {
        [Fact]
        public void CarParameterlessConstructorTest()
        {
            //arrange
            Vehicle vehicle = new Vehicle();
            //  act

            //assert
            vehicle.Should().BeOfType<Vehicle>();
        }

        [Fact]
        public void CarConstructorTest()
        {
            //arrange
            Vehicle vehicle = new(4, 10, "Ford", "Junker", 20);
            //  act

            //assert
            vehicle.NumberOfTires.Should().Be(4);
        }

//        [Theory]
//        [InlineData("Honda", "Civic")]
//        [InlineData("Honda", "Camry")]

//        IsValidModelForMakeAsyncTest(string Make, string Model)
//        {

//        }

//        [Fact]
//        WasModelMadeInYearAsyncNegativeTest()
//        {

//        }

//        [Theory]
//        [InlineData("Pants", "Jeans", 2022)]
//        [InlineData("Honda", "Camry", 2001)]
//        [InlineData("Subaru","WRX", 2020)]
//        [InlineData("Subaru", "WRX", 2000)]

//        WasModelMadeInYearAsyncPositiveTest()
//        {

//        }

//        [Fact]
//        AddPassengersTest:()
//      //  {  }

//        [Theory]
//        [InlineData( 5, 21, 3)]
//        [InlineData(5, 21,5)]
//        [InlineData(5, 21, 25)]

//        RemovePassengersTest:()
//        {

//        }
     }
 }
