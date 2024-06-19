using System.Collections.Generic;

namespace ContainerShipV2
{
    public class Row
    {
        public List<Stack> stackList = new List<Stack>();

        public int Width { get; set; }
        public int MaxHeight { get; set; }
        public Sides Side { get; set; }


        public Row(int width, Sides side)
        {
            Width = width;
            stackList = GetAllStackInRow();
            Side = side;
        }

        public enum Sides
        {
            Left = 1,
            Centre = 2,
            Right = 3,
        }

        public bool TryAddingContainer(Container container)
        {
            for (int i = 0; i < stackList.Count; i++)
            {
                Stack stack = stackList[i];
                if (stack.TryAddingContainer(container))
                {
                    if (CheckIfContainerNeedsReservedSpace(container, stack, i))
                    {
                        return true;
                    }

                    return true;
                }
            }

            return false;
        }

        private bool CheckIfContainerNeedsReservedSpace(Container container, Stack stack, int index)
        {
            if (container.ContainerType == Container.ContainerTypes.Valuable || container.ContainerType == Container.ContainerTypes.CoolableValuable)
            {
                if (stack.IsBack || stack.IsFront)
                {
                    return true;    
                }
                else if (index > 0 && !stackList[index - 1].Reserved && index + 1 < stackList.Count)
                {
                    stackList[index + 1].Reserved = true;
                    return true;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private List<Stack> GetAllStackInRow()
        {
            List<Stack> stacks = new List<Stack>();

            for (int i = 0; i < Width; i++) 
            {
                bool isFront = false;
                bool isBack = false;

                if (i == 0)
                {
                    isFront = true;
                }

                if ((i + 1) == Width)
                {
                    isBack = true;
                }

                stacks.Add(new Stack(i, isFront, isBack));
            }

            return stacks;
        }
    }

}

