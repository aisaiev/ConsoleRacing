using ConsoleRacing.Drawer;
using ConsoleRacing.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRacing.Figures
{
    public class RoadBorder : Figure
    {
        private readonly Field field;

        private int nodeCounter;

        public RoadBorder(ConsoleColor color, char symbol)
            : base(color, symbol) {
            this.field = new Field();
            this.nodeCounter = 1;
        }

        public override void InitializeState()
        {
            this.nodes = new List<Node>();
            this.GenerateBorder(this.field.Width, this.field.Height);
            new ConsoleDrawer().DrawFigure(this);
        }

        public override void Move(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.Down:
                    foreach (var node in new List<Node>(this.nodes))
                    {
                        node.MoveDown();
                        new ConsoleDrawer().ClearNode(node.X, node.Y - 1);
                    }
                    if (this.nodes[0].Y == this.field.Height - 1)
                    {
                        this.nodes.RemoveAt(0);
                        this.nodes.RemoveAt(0);
                        if (this.nodeCounter <= 3)
                        {
                            this.nodes.Add(new Node(1, 1));
                            this.nodes.Add(new Node(this.field.Width - 2, 1));
                        }
                    }
                    else
                    {
                        this.nodeCounter = 1;
                    }
                    break;
            }
        }

        public void GenerateBorder(int fieldWidth, int fieldHeight)
        {
            for (int i = fieldHeight - 2; i >= 1; i--)
            {
                if (i % 4 != 0)
                {
                    this.nodes.Add(new Node(1, i));
                    this.nodes.Add(new Node(fieldWidth - 2, i));
                }
            }
        }
    }
}
