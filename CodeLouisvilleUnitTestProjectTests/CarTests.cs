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



    }
}
