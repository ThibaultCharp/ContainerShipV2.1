using ContainerShipV2.Exceptions;
using ContainerShipV2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestContainerShip
{
    [TestClass]
    public class UnitTestShip
    {

        [TestMethod]
        public void Ship_Load_IsTooHeavy()
        {
            Ship ship = new Ship(1, 1);
            ContainerPlacer containerPlacer = new ContainerPlacer(ship);
            List<Container> containers = new List<Container>();


            containers.Add(new Container(30, 1));
            containers.Add(new Container(30, 1));
            containers.Add(new Container(30, 1));
            containers.Add(new Container(30, 1));
            containers.Add(new Container(30, 1));
            containers.Add(new Container(30, 1));

            foreach (Container container in containers)
            {
                containerPlacer.Ship.Containers.Add(container);
            }

            Assert.ThrowsException<ShipException>(() => containerPlacer.Ship.CheckContainersAndDistributeContainers());

        }

        [TestMethod]
        public void Ship_Load_IsTooLight()
        {
            Ship ship = new Ship(3, 1);
            ContainerPlacer containerPlacer = new ContainerPlacer(ship);
            List<Container> containers = new List<Container>();


            containers.Add(new Container(4, 1));


            foreach (Container container in containers)
            {
                containerPlacer.Ship.Containers.Add(container);
            }

            Assert.ThrowsException<ContainerException>(() => containerPlacer.Ship.CheckContainersAndDistributeContainers());

        }

        [TestMethod]
        public void Ship_Load_TooManyCoolables()
        {
            Ship ship = new Ship(1, 1);
            ContainerPlacer containerPlacer = new ContainerPlacer(ship);
            List<Container> containers = new List<Container>();

            containers.Add(new Container(30, 3));
            containers.Add(new Container(30, 3));
            containers.Add(new Container(30, 3));
            containers.Add(new Container(30, 3));
            containers.Add(new Container(30, 3));
            containers.Add(new Container(30, 3));

            foreach (Container container in containers)
            {
                containerPlacer.Ship.Containers.Add(container);
            }

            Assert.ThrowsException<ShipException>(() => containerPlacer.Ship.CheckContainersAndDistributeContainers());
        }

        [TestMethod]
        public void Ship_Distribute_IsTrue()
        {
            Ship ship = new Ship(2, 2);
            ContainerPlacer containerPlacer = new ContainerPlacer(ship);
            List<Container> containers = new List<Container>();

            containers.Add(new Container(30, 1));
            containers.Add(new Container(30, 1));

            foreach (Container container in containers)
            {
                containerPlacer.Ship.Containers.Add(container);
            }

            Assert.IsTrue(containerPlacer.Ship.DistributeContainers());
        }
    }

}
