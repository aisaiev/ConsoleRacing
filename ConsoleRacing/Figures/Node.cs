using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRacing.Figures
{
    public class Node
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Node(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void MoveDown()
        {
            this.Y++;
        }

        public void MoveLeft()
        {
            this.X--;
        }

        public void MoveRight()
        {
            this.X++;
        }
    }
}
