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
            vehicle.NumberOfTires.Should().Be<Vehicle>(4);
        }



    }
}
