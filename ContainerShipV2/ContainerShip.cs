using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ContainerShipV2
{
    public partial class ContainerShip : Form
    {

        List<Container> FormContainers = new List<Container>();

        public ContainerShip()
        {
            InitializeComponent();
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            ContainerPlacer containerPlacer = new ContainerPlacer(new Ship(6, 3));

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
            FormContainers.Add(new Container(30, 4));
            FormContainers.Add(new Container(30, 4));
            FormContainers.Add(new Container(30, 4));
            FormContainers.Add(new Container(30, 4));
            FormContainers.Add(new Container(30, 4));


            foreach (Container container in FormContainers)
            {
                containerPlacer.Ship.Containers.Add(container);
            }

            containerPlacer.Ship.CheckContainersAndDistributeContainers();
        }
    }
}
