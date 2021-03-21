using ConsoleRacing.Figures;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleRacing.Drawer
{
    public class ConsoleDrawer
    {
        public void DrawFigure(Figure figure, Field field = null)
        {
            if (figure is MainCar || figure is RoadBorder)
            {
                foreach (var node in figure.nodes)
                {
                    Console.ForegroundColor = figure.Color;
                    Console.SetCursorPosition(node.X, node.Y);
                    Console.Write(figure.Symbol);
                }
            }
            else if (figure is RivalCar)
            {
                foreach (var item in figure.nodes)
                {
                    if (item.Y >= field?.Height - field?.Height + 1)
                    {
                        Console.ForegroundColor = figure.Color;
                        Console.SetCursorPosition(item.X, item.Y);
                        Console.Write(figure.Symbol);
                    }
                }
            }
        }

        public void ClearNode(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public void DrawField(Field field)
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 1; i <= field.Height; i++)
            {
                for (int j = 1; j <= field.Width; j++)
                {
                    if (i == 1 || i == field.Height)
                    {
                        Console.Write('-');
                    }
                    else if (j == 1 || j == field.Width)
                    {
                        Console.Write('|');
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.SetCursorPosition(field.Width + 1, 1);
            Console.Write($"Level: -");
            Console.SetCursorPosition(field.Width + 1, 3);
            Console.Write("Score: 0");
            Console.SetCursorPosition(field.Width + 1, 5);
            Console.Write("Time in game: 0m 0s");
        }

        public void DrawGameLevel(Field field, string gameLevel)
        {
            Console.SetCursorPosition(field.Width + 1, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Level: {gameLevel}");
        }

        public void DrawScore(Field field, int score)
        {
            Console.SetCursorPosition(field.Width + 1, 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Score: {score}");
        }

        public void DrawTimeInGame(Field field, TimeSpan timeSpan)
        {
            Console.SetCursorPosition(field.Width + 1, 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Time in game: {timeSpan.Minutes}m {timeSpan.Seconds}s");
        }

        public void DrawGameOver(Field field)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 1; i <= field.Height; i++)
            {
                for (int j = 1; j <= field.Width; j++)
                {
                    if (i == 1 || i == field.Height)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write('-');
                    }
                    else if (j == 1 || j == field.Width)
                    {
                        if (i != field.Height / 2 - 1 && i != field.Height / 2)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write('|');
                        }
                    }
                    else
                    {
                        if (i != field.Height / 2 - 1 && i != field.Height / 2)
                        {
                            Thread.Sleep(15);
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write('#');
                        }
                        else if (i == field.Height / 2 - 1)
                        {
                            Console.SetCursorPosition(4, 8 - 1);
                            Console.Write("GAME");
                        }
                        else if (i == field.Height / 2)
                        {
                            Console.SetCursorPosition(4, 8);
                            Console.Write("OVER");
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public void DrawCountDown()
        {
            string threeNumber = "   ____  " +
                Environment.NewLine + "  |___ \\ " +
                Environment.NewLine + "    __) |" +
                Environment.NewLine + "   |__ < " +
                Environment.NewLine + "   ___) |" +
                Environment.NewLine + "  |____/";
            string twoNumber = "   ___  " +
                Environment.NewLine + "  |__ \\ " +
                Environment.NewLine + "     ) |" +
                Environment.NewLine + "    / / " +
                Environment.NewLine + "   / /_ " +
                Environment.NewLine + "  |____|";
            string oneNumber = "   __ " +
                Environment.NewLine + "  /_ |" +
                Environment.NewLine + "   | |" +
                Environment.NewLine + "   | |" +
                Environment.NewLine + "   | |" +
                Environment.NewLine + "   |_|";
            string goString = "  _____  ____  " +
                Environment.NewLine + " / ____|/ __ \\ " +
                Environment.NewLine + "| |  __| |  | |" +
                Environment.NewLine + "| | |_ | |  | |" +
                Environment.NewLine + "| |__| | |__| |" +
                Environment.NewLine + " \\_____|\\____/";
            List<string> countDownItems = new List<string>
            {
                threeNumber,
                twoNumber,
                oneNumber,
                goString
            };
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in countDownItems)
            {
                Console.WriteLine(item);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
