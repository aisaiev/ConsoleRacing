using ConsoleRacing.Drawer;
using ConsoleRacing.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRacing.Figures
{
    public class RivalCar : Figure
    {
        private Field field;

        public RivalCar(ConsoleColor color, char symbol)
            : base(color, symbol) { }

        public override void InitializeState()
        {
            this.field = new Field();
            this.nodes = new List<Node>();
            this.GenerateRivalCar();
        }

        public void GenerateRivalCar()
        {
            Random rnd = new Random();
            switch (rnd.Next(1, 3))
            {
                case 1:
                    this.nodes = new List<Node>
                    {
                        new Node(this.field.Width - 6, this.field.Height - this.field.Height - 2),
                        new Node(this.field.Width - 4, this.field.Height - this.field.Height - 2),
                        new Node(this.field.Width - 5, this.field.Height - this.field.Height - 3),
                        new Node(this.field.Width - 5, this.field.Height - this.field.Height - 4),
                        new Node(this.field.Width - 5, this.field.Height - this.field.Height - 5),
                        new Node(this.field.Width - 6, this.field.Height - this.field.Height - 4),
                        new Node(this.field.Width - 4, this.field.Height - this.field.Height - 4)
                    };
                    break;
                case 2:
                    this.nodes = new List<Node>
                    {
                        new Node(this.field.Width - 9, this.field.Height - this.field.Height - 2),
                        new Node(this.field.Width - 7, this.field.Height - this.field.Height - 2),
                        new Node(this.field.Width - 8, this.field.Height - this.field.Height - 3),
                        new Node(this.field.Width - 8, this.field.Height - this.field.Height - 4),
                        new Node(this.field.Width - 8, this.field.Height - this.field.Height - 5),
                        new Node(this.field.Width - 9, this.field.Height - this.field.Height - 4),
                        new Node(this.field.Width - 7, this.field.Height - this.field.Height - 4)
                    };
                    break;
            }
        }

        public override void Move(MoveDirection moveDirection)
        {
            foreach (var node in new List<Node>(this.nodes))
            {
                if (node.Y >= this.field.Height - this.field.Height + 1)
                {
                    new ConsoleDrawer().ClearNode(node.X, node.Y);
                }
                node.MoveDown();
                if (node.Y == this.field.Height - 1)
                {
                    this.nodes.Remove(node);
                }
            }
        }
    }
}
