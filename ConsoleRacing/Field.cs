using ConsoleRacing.Drawer;
using ConsoleRacing.Enum;
using ConsoleRacing.Figures;
using ConsoleRacing.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRacing
{
    public class Field
    {
        public Figure MainCar { get; private set; }

        public List<Figure> RivalCars { get; private set; }

        public Figure RoadBorder { get; private set; }

        public KeyboardHandler KeyboardHandler { get; private set; }

        private readonly ConsoleDrawer drawer;

        public readonly int Width = 12;

        public readonly int Height = 18;

        public Field(Figure roadBorder, Figure mainCar, List<Figure> rivalCars)
        {
            this.RoadBorder = roadBorder;
            this.MainCar = mainCar;
            this.RivalCars = rivalCars;
            this.drawer = new ConsoleDrawer();
            this.InitializeState();
            this.RoadBorder.InitializeState();
            this.MainCar.InitializeState();
            this.RivalCars[0].InitializeState();
            this.KeyboardHandler = new KeyboardHandler();
            this.KeyboardHandler.KeyLeft += this.OnKeyLeft;
            this.KeyboardHandler.KeyRight += this.OnKeyRight;
        }

        public Field()
        {
        }

        private void InitializeState()
        {
            this.drawer.DrawField(this);
        }

        private void OnKeyRight(object sender, EventArgs e)
        {
            if (this.IsManoeuvreAvailable(MoveDirection.Right))
            {
                foreach (var node in this.MainCar.nodes)
                {
                    this.drawer.ClearNode(node.X, node.Y);
                }
                this.MainCar.Move(MoveDirection.Right);
                this.drawer.DrawFigure(this.MainCar);
            }
        }

        private void OnKeyLeft(object sender, EventArgs e)
        {
            if (this.IsManoeuvreAvailable(MoveDirection.Left))
            {
                foreach (var node in this.MainCar.nodes)
                {
                    this.drawer.ClearNode(node.X, node.Y);
                }
                this.MainCar.Move(MoveDirection.Left);
                this.drawer.DrawFigure(this.MainCar);
            }
        }

        public bool IsMainCarOnRivalCar()
        {
            foreach (var mainCarNode in this.MainCar.nodes)
            {
                foreach (var rivalCar in this.RivalCars)
                {
                    foreach (var rivalCarNode in rivalCar.nodes)
                    {
                        if (mainCarNode.X == rivalCarNode.X && mainCarNode.Y == rivalCarNode.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool IsManoeuvreAvailable(MoveDirection direction)
        {
            if (direction == MoveDirection.Left)
            {
                Node theLeftmostMainCarNode = this.MainCar.nodes.OrderBy(node => node.X).First();

                return !(theLeftmostMainCarNode.X - 3 <= 1);
            }
            else if (direction == MoveDirection.Right)
            {
                Node theRightmostMainCarNode = this.MainCar.nodes.OrderByDescending(node => node.X).First();

                return !(theRightmostMainCarNode.X + 3 >= this.Width - 1);
            }
            return false;
        }
    }
}
