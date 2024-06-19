using ContainerShipV2.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ContainerShipV2
{
    public class Ship
    {
        public readonly List<Container> Containers;
        public List<Container> sortedContainers;
        private readonly List<Row> RowList = new List<Row>();

        public int Width { get; private set; }
        public int Length { get; private set; }
        public int MaxWeight { get; private set; }
        public int MinWeight { get; private set; }
        public int TotalSlots { get; private set; }

        private int WeightLeft;
        private int WeightRight;

        private double WeightDifferencePercentage
        {
            get
            {
                return ((WeightLeft / TotalWeight) * 100) - ((WeightRight / TotalWeight) * 100);
            }
        }

        private int TotalWeight
        {
            get
            {
                int totalWeight = 0;
                foreach (Container container in Containers)
                {
                    totalWeight += container.Weight;
                }
                return totalWeight;
            }
        }

        public Ship(int lenght, int width)
        {
            Width = width;
            Length = lenght;
            MaxWeight = (lenght * width) * 150;
            MinWeight = MaxWeight / 2;
            Containers = new List<Container>();
            sortedContainers = new List<Container>();
            CheckIfRowsAreEvenOrUneven();
        }

        public void CheckContainersAndDistributeContainers()
        {
            int totalWeightFirstRow = Width * 150;
            int totalWeightCoolables = 0;

            foreach (Container container in Containers)
            {
                if (container.ContainerType == Container.ContainerTypes.Coolable || container.ContainerType == Container.ContainerTypes.CoolableValuable)
                {
                    totalWeightCoolables += container.Weight;
                }
            }

            if (totalWeightFirstRow < totalWeightCoolables)
            {
                throw new ShipException("Too many coolables!!!!");
            }

            if (TotalWeight > MaxWeight)
            {
                throw new ShipException("Load is too heavy");
            }

            if (TotalWeight < MinWeight)
            {
                throw new ContainerException("Containers are too light");
            }



            if (DistributeContainers())
            {
                if (WeightDifferencePercentage > 20)
                {
                    throw new ShipException("Ship is capsizing");
                }

                StartVisualizer();
            }
        }

        public bool DistributeContainers()
        {
            sortedContainers = Containers.OrderByDescending(o => o.ContainerType).ThenBy(o => o.Weight).ToList();

            foreach (Container container in sortedContainers)
            {
                if (!AddContainerLeftOrRight(container))
                {
                    AddContainerCenter(container);
                }
            }
            
            return true;
        }

        private bool AddContainerLeftOrRight(Container container)
        {
            foreach (Row row in RowList)
            {
                if ((WeightLeft < WeightRight && row.Side == Row.Sides.Left) || (WeightLeft >= WeightRight && row.Side == Row.Sides.Right))
                {
                    if (row.TryAddingContainer(container))
                    {
                        if (WeightLeft < WeightRight)
                        {
                            WeightLeft += container.Weight;
                        }
                        else
                        {
                            WeightRight += container.Weight;
                        }

                        return true;
                    }
                }
            }

            return false;
        }

        private void AddContainerCenter(Container container)
        {
            foreach (Row row in RowList)
            {
                if (row.Side == Row.Sides.Centre)
                {
                    if (row.TryAddingContainer(container))
                    {
                        return;
                    }
                }
            }
        }

        private void CheckIfRowsAreEvenOrUneven()
        {
            for (int i = 0; i < Width; i++)
            {
                Row.Sides side;

                if (Width % 2 == 0)
                {
                    side = CalculateEvenRows(i);
                }
                else
                {
                    side = CalculateUnevenRows(i);
                }

                RowList.Add(new Row(Length, side));
            }
        }

        private Row.Sides CalculateEvenRows(int i)
        {
            Row.Sides side;
            if (i < Width / 2)
            {
                side = Row.Sides.Left;
            }
            else
            {
                side = Row.Sides.Right;
            }

            return side;
        }

        private Row.Sides CalculateUnevenRows(int i)
        {
            Row.Sides side;

            if (i < Width / 2)
            {
                side = Row.Sides.Left;
            }
            else if (i > Width / 2)
            {
                side = Row.Sides.Right;
            }
            else
            {
                side = Row.Sides.Centre;
            }

            return side;
        }

        public string StartVisualizer()
        {
            string stack = "";
            string weight = "";
            for (int z = 0; z < RowList.Count; z++)
            {
                if (z > 0)
                {
                    stack += '/';
                    weight += '/';
                }

                for (int x = 0; x < RowList[z].stackList.Count; x++)
                {
                    if (x > 0)
                    {
                        stack += ",";
                        weight += ",";
                    }

                    if (RowList[z].stackList[x].containers.Count > 0)
                    {
                        for (int y = 0; y < RowList[z].stackList[x].containers.Count; y++)
                        {
                            Container container = RowList[z].stackList[x].containers[y];

                            stack += Convert.ToString((int)container.ContainerType);
                            weight += Convert.ToString(container.Weight);
                            if (y < (RowList[z].stackList[x].containers.Count - 1))
                            {
                                weight += "-";
                            }
                        }
                    }
                }
            }

            Process.Start($"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Length + "&width=" + Width + "&stacks=" + stack + "&weights=" + weight + "");
            return $"https://i872272.luna.fhict.nl/ContainerVisualizer/index.html?length=" + Length + "&width=" + Width + "&stacks=" + stack + "&weights=" + weight + "";
        }
    }
}
