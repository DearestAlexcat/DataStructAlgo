using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DataStructAlgo.Algorithms.Breadth_Depth_first
{
    struct Coord
    {
        public int x;
        public int y;
    }

    class Map
    {
        int size_x, size_y;

        int[,] map = null;

        string symbol = " #+*";

        ConsoleColor[] colors =
        {
            ConsoleColor.White,
            ConsoleColor.Blue,
            ConsoleColor.Green,
            ConsoleColor.Red
        };

        public Map(int size_x, int size_y)
        {
            this.size_x = size_x;
            this.size_y = size_y;
            map = new int[size_x, size_y];
        }

        public void SetMap(int number_attempts)
        {
            Random random = new Random();

            for (int i = 0; i < number_attempts; i++)
            {
                SetElement(random.Next(size_x), random.Next(size_y), 1);
            }
        }

        public void SetElement(int x, int y, int number)
        {
            map[x, y] = number;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = colors[number];
            Console.Write(symbol[number]);
        }

        bool CheckСoordinate(int x, int y)
        {
            if (x < 0 || x >= size_x)
                return false;
            if (y < 0 || y >= size_y)
                return false;
            return map[x, y] == 0;
        }

        public void FillFor(int px, int py) // Iterative search
        {
            if (!CheckСoordinate(px, py))
                return;

            SetElement(px, py, 2);

            while (true)
            {
                bool exit = true;

                for (int x = 0; x < size_x; x++)
                {
                    for (int y = 0; y < size_y; y++)
                    {
                        if (map[x, y] == 2)
                        {
                            exit = false;
                            if (CheckСoordinate(x - 1, y)) SetElement(x - 1, y, 3);
                            if (CheckСoordinate(x, y + 1)) SetElement(x, y + 1, 3);
                            if (CheckСoordinate(x + 1, y)) SetElement(x + 1, y, 3);
                            if (CheckСoordinate(x, y - 1)) SetElement(x, y - 1, 3);
                        }
                    }
                }

                if (exit == true)
                {
                    break;
                }

                for (int x = 0; x < size_x; x++)
                {
                    for (int y = 0; y < size_y; y++)
                    {
                        if (map[x, y] == 3)
                        {
                            Thread.Sleep(100);
                            SetElement(x, y, 2);
                        }
                    }
                }
            }
        }

        public void FillQueue(int px, int py) // Breadth-first search  
        {
            if (!CheckСoordinate(px, py))
                return;

            Queue<Coord> queue = new Queue<Coord>();

            queue.Enqueue(new Coord { x = px, y = py });

            Coord coord;

            while (queue.Count > 0)
            {
                coord = queue.Dequeue();
                px = coord.x;
                py = coord.y;

                SetElement(px, py, 2);

                Thread.Sleep(50);

                if (CheckСoordinate(px - 1, py))
                {
                    SetElement(px - 1, py, 3);
                    queue.Enqueue(new Coord { x = px - 1, y = py });
                }
                if (CheckСoordinate(px, py + 1))
                {
                    SetElement(px, py + 1, 3);
                    queue.Enqueue(new Coord { x = px, y = py + 1 });
                }
                if (CheckСoordinate(px + 1, py))
                {
                    SetElement(px + 1, py, 3);
                    queue.Enqueue(new Coord { x = px + 1, y = py });
                }
                if (CheckСoordinate(px, py - 1))
                {
                    SetElement(px, py - 1, 3);
                    queue.Enqueue(new Coord { x = px, y = py - 1 });
                }
            }
        }

        public void FillStack(int px, int py)  // Depth-first search
        {
            if (!CheckСoordinate(px, py))
                return;

            Stack<Coord> queue = new Stack<Coord>();

            queue.Push(new Coord { x = px, y = py });

            Coord coord;

            while (queue.Count > 0)
            {
                coord = queue.Pop();

                px = coord.x;
                py = coord.y;

                SetElement(px, py, 2);

                Thread.Sleep(50);

                if (CheckСoordinate(px - 1, py))
                {
                    SetElement(px - 1, py, 3);
                    queue.Push(new Coord { x = px - 1, y = py });
                }
                if (CheckСoordinate(px, py + 1))
                {
                    SetElement(px, py + 1, 3);
                    queue.Push(new Coord { x = px, y = py + 1 });
                }
                if (CheckСoordinate(px + 1, py))
                {
                    SetElement(px + 1, py, 3);
                    queue.Push(new Coord { x = px + 1, y = py });
                }
                if (CheckСoordinate(px, py - 1))
                {
                    SetElement(px, py - 1, 3);
                    queue.Push(new Coord { x = px, y = py - 1 });
                }
            }
        }

        public void FillDepth(int x, int y) // Depth-first recursive search
        {
            if (!CheckСoordinate(x, y))
                return;

            Thread.Sleep(50);
            SetElement(x, y, 3);

            FillDepth(x - 1, y);
            FillDepth(x, y + 1);
            FillDepth(x + 1, y);
            FillDepth(x, y - 1);

            SetElement(x, y, 2);
        }
    }
}
