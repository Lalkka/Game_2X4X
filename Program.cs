using System;

namespace Game_2X4X
{
    internal class RNDM
    {
        static Random random = new Random();
        public static int Random0 => random.Next(5, 10);
        public static int Random1 => random.Next(10, 20);
        public static int Random2 => random.Next(20, 40);

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
                Bag = 10, BigBag = 20;

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
                        Hungry = 100; HP -= RNDM.Random1;
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
                        if (NeedSleep > 90)
                        {
                            Console.Clear();
                            Console.WriteLine("У вас нет сил для этого");
                        }
                        else
                        {
                            Hungry += RNDM.Random2; NeedSleep += RNDM.Random1; Day++;
                            Console.Clear();
                            Console.WriteLine("Вы осматриваетесь");




                        }
                    }
                    else if (Choice == "2")
                    {
                        if (NeedSleep > 90)
                        {
                            Console.Clear();
                            Console.WriteLine("У вас нет сил для этого");
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
                        NeedSleep = 0; Hungry += RNDM.Random0; Day++;


                    }


                    Console.ReadLine();
                }
            }
        }
    }
}

