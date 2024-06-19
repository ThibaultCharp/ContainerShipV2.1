using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShipV2.Exceptions
{
    public class ShipException : Exception
    {
        public ShipException() { }
        public ShipException(string message) : base(message) { }
        public ShipException(string message, Exception innerException) : base(message, innerException) { }
    }
}
