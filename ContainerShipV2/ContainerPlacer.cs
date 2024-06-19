using ContainerShipV2.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ContainerShipV2
{
    public class ContainerPlacer
    {
        public readonly Ship Ship;

        public ContainerPlacer(Ship ship)
        {
            Ship = ship;
        }
    }
}
