using System.Collections.Generic;
using System.Linq;

namespace ContainerShipV2
{
    public class Stack
    {
        public List<Container> containers = new List<Container>();

        public int Position { get; set; }
        public bool IsFront { get; private set; }
        public bool IsBack { get; private set; }
        public bool Reserved { get; set; }
        public bool StackIsFull { get; set; }

        private readonly int BaseMaxWeight = 120;
        public int MaxWeight
        {
            get
            {
                if (containers.Count > 0)
                {
                    return BaseMaxWeight + containers[0].Weight;
                }
                return BaseMaxWeight;
            }
        }

        public int ContainersWeight
        {
            get
            {
                int totalWeight = 0;
                foreach (var container in containers)
                {
                    totalWeight += container.Weight;
                }
                return totalWeight;
            }
        }

        public Stack(int position, bool isfront, bool isBack)
        {
            Position = position;
            IsFront = isfront;
            IsBack = isBack;
        }

        public bool TryAddingContainer(Container container)
        {
            if (container.ContainerType == Container.ContainerTypes.Coolable && Position > 0 || Reserved)
            {
                return false;
            }

            if (ContainersWeight + container.Weight <= MaxWeight)
            {
                if (container.ContainerType == Container.ContainerTypes.Valuable || container.ContainerType == Container.ContainerTypes.CoolableValuable)
                {
                    if (containers.Count == 0 || containers.LastOrDefault().ContainerType != Container.ContainerTypes.Valuable)
                    {
                        containers.Add(container);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    containers.Insert(0, container);
                }

                if (ContainersWeight + container.Weight >= MaxWeight)
                {
                    StackIsFull = true;
                }

                return true;
            }

            return false;
        }
    }
}
