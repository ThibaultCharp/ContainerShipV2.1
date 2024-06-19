using ContainerShipV2;
using ContainerShipV2.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestContainerShip
{
    [TestClass]
    public class UnitTestContainer
    {
        [TestMethod]
        public void Container_Constructor_ThrowsException_WhenWeightIsBelowMinimum()
        {
            ContainerException exception = Assert.ThrowsException<ContainerException>(() => new Container(3, 1));

            Assert.AreEqual("Weight mininum is 4 tons", exception.Message);
        }

        [TestMethod]
        public void Container_Constructor_WhenWeightIsAboveMaximum()
        {
            ContainerException exception = Assert.ThrowsException<ContainerException>(() => new Container(31, 1));

            Assert.AreEqual("Weight maximun is 30 tons", exception.Message);
        }
    }
}
