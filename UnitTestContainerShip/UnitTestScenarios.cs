using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ContainerShipV2;
using System.Collections.Generic;

namespace UnitTestContainerShip
{
    [TestClass]
    public class UnitTestScenarios
    {

        [TestMethod]
        public void Scenario_1()
        {
            List<Container> FormContainers = new List<Container>();

            Ship ship = new Ship(2, 3);
            ContainerPlacer placer = new ContainerPlacer(ship);


            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container( 4, 1));
            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 2));

            foreach (Container container in FormContainers)
            {
                placer.Ship.Containers.Add(container);
            }

            placer.Ship.CheckContainersAndDistributeContainers();

            Assert.AreEqual("https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=2&width=3&stacks=13332,11112/11,/13332,11112&weights=30-30-30-30-30,30-30-30-30-30/30-30,/4-30-30-30-30,30-30-30-30-30"
                , ship.StartVisualizer());
        }

        [TestMethod]
        public void Scenario_2()
        {
            List<Container> FormContainers = new List<Container>();

            Ship ship = new Ship(2, 2);
            ContainerPlacer placer = new ContainerPlacer(ship);

            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));

            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));

            foreach (Container container in FormContainers)
            {
                placer.Ship.Containers.Add(container);
            }

            placer.Ship.CheckContainersAndDistributeContainers();



            Assert.AreEqual("https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=2&width=2&stacks=11112,2/11112,2&weights=30-30-30-30-30,30/30-30-30-30-30,30"
                , ship.StartVisualizer());
        }

        [TestMethod]
        public void Scenario_3()
        {
            List<Container> FormContainers = new List<Container>();

            Ship ship = new Ship(6, 3);
            ContainerPlacer placer = new ContainerPlacer(ship);

            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));
            FormContainers.Add(new Container(30, 2));

            FormContainers.Add(new Container(30, 3));
            FormContainers.Add(new Container(30, 3));

            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));
            FormContainers.Add(new Container(30, 1));


            foreach (Container container in FormContainers)
            {
                placer.Ship.Containers.Add(container);
            }

            placer.Ship.CheckContainersAndDistributeContainers();

            Assert.AreEqual("https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=6&width=3&stacks=11132,11112,,11112,11111,11/,,,,,/11132,11112,,11112,11111,111&weights=30-30-30-30-30,30-30-30-30-30,,30-30-30-30-30,30-30-30-30-30,30-30/,,,,,/30-30-30-30-30,30-30-30-30-30,,30-30-30-30-30,30-30-30-30-30,30-30-30"
                , ship.StartVisualizer());
        }
    }
}
