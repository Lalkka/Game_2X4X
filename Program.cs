using System;
using System.ComponentModel;

namespace Game_2X4X
{
    internal class HELP
    {
        static Random random = new Random();
        public static int Random0 => random.Next(5, 10);
        public static int Random1 => random.Next(10, 20);
        public static int Random2 => random.Next(20, 40);
    }
    public class Player
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }

        public Player(int startX, int startY)
        {
            PosX = startX;
            PosY = startY;
        }

        public static void StartExplore()
        {
            Console.Clear();

            int Item = 0;
            int MapHeight = 10;
            int MapWidth = 20;
            int[,] Map = new int[MapHeight, MapWidth];
            Random Random = new Random();

            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (y == 0 || y == MapHeight - 1 || x == 0 || x == MapWidth - 1)
                    {
                        Map[y, x] = 1; 
                        continue;
                    }

                    int Chance = Random.Next(0, 100);
                    if (Chance < 20) Map[y, x] = 1;
                    else if (Chance < 35) Map[y, x] = 2;
                    else Map[y, x] = 0;
                }
            }
            Map[1, 1] = 0;

            
            for (int y = 0; y < MapHeight; y++)
            {
                for (int x = 0; x < MapWidth; x++)
                {
                    if (Map[y, x] == 1) Console.Write("#");
                    else if (Map[y, x] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("$");
                        Console.ResetColor();
                    }
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, MapHeight + 1);
            Console.WriteLine("Управление: WASD. Нажмите Escape для выхода.");

            Player O = new Player(1, 1);
            O.DrawPlayer();

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }

                int NextX = O.PosX;
                int NextY = O.PosY;

                if (key.Key == ConsoleKey.D) NextX++;
                else if (key.Key == ConsoleKey.W) NextY--;
                else if (key.Key == ConsoleKey.A) NextX--;
                else if (key.Key == ConsoleKey.S) NextY++;

                if (Map[NextY, NextX] != 1)
                {
                    Console.SetCursorPosition(O.PosX, O.PosY);
                    Console.Write(" "); // Стираем старый след

                    O.PosX = NextX;
                    O.PosY = NextY;

                    // Если наступили на ресурс
                    if (Map[O.PosY, O.PosX] == 2)
                    {
                        Map[O.PosY, O.PosX] = 0;
                        Console.SetCursorPosition(0, MapHeight + 3);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("Вы нашли ресурсы!                ");
                        Console.ResetColor();
                    }

                    O.DrawPlayer();
                }
                Console.SetCursorPosition(0, MapHeight + 5);
            }
        }

        private void DrawPlayer()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
            Console.ResetColor();
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("          2X4X");
            Console.ResetColor();
            Console.WriteLine("Нажмите что-бы продолжить");
            Console.ReadLine();
            while (true)
            {
                int HP = 100, NeedSleep = 0, Hungry = 0, Day = 1,
                Inv = 0, InvMax = 20,
                Rock = 1, stick = 1, Scrap = 2, Rope = 2, Rags = 1,
                AidKit = 5, Bandage = 3, Knife = 5, Machete = 7, Axe = 5,
                Bag = 10, BigBag = 20,
                Item = 0;

                bool IsAlive = true;
                while (IsAlive)
                {
                    Console.Clear();
                    if (HP < 0)
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("\tВы мертвы");
                            Console.ResetColor();
                            Console.WriteLine("\tПовторить?\n[Y/N]");
                            string Choice0 = Console.ReadLine();
                            if (Choice0 == "Y")
                            {
                                IsAlive = false;
                                Console.Clear();
                                break;
                            }
                            else if (Choice0 == "N")
                            {
                                Environment.Exit(0);
                            }
                            else;
                        }
                    }
                    if (Hungry > 100)
                    {
                        Hungry = 100; HP -= HELP.Random1;
                        Console.Write("Вы очень голодны");
                    }
                    if (NeedSleep > 100)
                    {
                        NeedSleep = 100;
                    }

                    Console.WriteLine($"\tДень:{Day}  Здоровье:{HP}  Голод:{Hungry}  Усталость:{NeedSleep}");
                    Console.WriteLine($"\n[1] Осмотреться\n[2] Инвентарь\n[3] Отдохнуть");
                    string Choice = Console.ReadLine();
                    if (Choice == "1")
                    {
                        if (NeedSleep > 80)
                        {
                            Console.Clear();
                            Console.WriteLine("У вас нет сил для этого, отдохните!");
                        }
                        else
                        {
                            Hungry += HELP.Random2; NeedSleep += HELP.Random1; Day++;
                            Console.Clear();
                            Console.WriteLine("Вы осматриваетесь");
                            Player.StartExplore();

                        }
                    }
                    else if (Choice == "2")
                    {
                        if (NeedSleep > 95)
                        {
                            Console.Clear();
                            Console.WriteLine("У вас нет сил для этого, отдохните!");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Инвентарь");
                        }
                    }
                    else if (Choice == "3")
                    {
                        Console.Clear();
                        Console.WriteLine("Вы отдыхаете, параметр усталости восстановлен!");
                        NeedSleep = 0; Hungry += HELP.Random0; Day++;
                    }
                    Console.ReadLine();
                }
            }
        }
    }
}
