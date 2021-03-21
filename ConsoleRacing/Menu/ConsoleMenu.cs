using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRacing.Menu
{
    public class ConsoleMenu
    {
        public ConsoleMenu ParentMenu { get; set; }

        public string Header { get; set; }

        public string SubTitle { get; set; }

        public string CursorText { get; set; }

        public ConsoleColor CursorColor { get; set; }

        public ConsoleColor HeaderColor { get; set; }

        public ConsoleColor ForegroundColor { get; set; }

        public ConsoleColor MenuItemColor { get; set; }

        public ConsoleColor SubTitleColor { get; set; }

        private List<MenuItem> menuItemList;

        private int cursor;

        private bool isExited;

        public ConsoleMenu(string cursorText = "->")
        {
            this.menuItemList = new List<MenuItem>();
            this.cursor = 0;
            this.CursorText = cursorText;
            this.CursorColor = ConsoleColor.Yellow;
            this.HeaderColor = ConsoleColor.Green;
            this.ForegroundColor = ConsoleColor.White;
            this.MenuItemColor = ConsoleColor.White;
            this.SubTitleColor = ConsoleColor.White;
        }

        public bool AddMenuItem(int id, string text, Action action)
        {
            if (!this.menuItemList.Any(item => item.Id == id))
            {
                this.menuItemList.Add(new MenuItem(id, text, action));
                return true;
            }
            return false;
        }

        private void DrawHeader()
        {
            Console.ForegroundColor = this.HeaderColor;
            Console.WriteLine(this.Header);
            Console.ForegroundColor = this.ForegroundColor;
        }

        private void DrawWithHeader()
        {
            this.DrawHeader();
            this.Draw();
        }

        private void Draw()
        {
            Console.WriteLine(this.SubTitle);
            for (int i = 0; i < this.menuItemList.Count; i++)
            {
                if (i == this.cursor)
                {
                    Console.ForegroundColor = this.CursorColor;
                    Console.Write(this.CursorText + " ");
                    Console.WriteLine(this.menuItemList[i].Text);
                    Console.ForegroundColor = this.ForegroundColor;
                }
                else
                {
                    Console.Write(new string(' ', (this.CursorText.Length + 1)));
                    Console.WriteLine(this.menuItemList[i].Text);
                }
            }
        }

        private void Clear()
        {
            Console.Clear();
        }

        public void ShowMenu()
        {
            Console.CursorVisible = false;
            this.Clear();
            this.DrawWithHeader();
            this.isExited = false;
            while (!this.isExited)
            {
                this.UpdateMenu();
            }
        }

        public void HideMenu()
        {
            this.isExited = true;
        }

        private void UpdateMenu()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (this.cursor > 0)
                        {
                            this.cursor--;
                            Console.Clear();
                            this.DrawWithHeader();
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (this.cursor < (this.menuItemList.Count - 1))
                        {
                            this.cursor++;
                            Console.Clear();
                            this.DrawWithHeader();
                        }
                    }
                    break;
                case ConsoleKey.Enter:
                    {
                        Console.Clear();
                        this.DrawHeader();
                        Console.CursorVisible = true;
                        this.menuItemList[this.cursor].Action();
                        Console.CursorVisible = false;
                        Console.Clear();
                        this.DrawWithHeader();
                    }
                    break;
                case ConsoleKey.Escape:
                    {
                        if (this.ParentMenu != null)
                        {
                            this.HideMenu();
                        }
                    }
                    break;
            }
        }
    }
}
