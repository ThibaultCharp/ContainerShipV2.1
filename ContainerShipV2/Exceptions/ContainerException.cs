using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShipV2.Exceptions
{
    public class ContainerException : Exception
    {
        public ContainerException() { }
        public ContainerException(string message) : base(message) { }
        public ContainerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
