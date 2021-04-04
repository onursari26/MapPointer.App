using MapPointer.App.Map;
using MapPointer.App.ZoneCounter;
using System;

namespace MapPointer.App
{
    class Program
    {
        private static void CreateRandomMap(MapInterface map)
        {
            Random rnd = new();

            int randomWidth = (rnd.Next() % 45) + 5;
            int randomHeight = (rnd.Next() % 15) + 5;
            int randomAmountOfBorders = (rnd.Next() % 8) + 3;

            map.SetSize(randomWidth, randomHeight);

            for (int n = 0; n <= randomAmountOfBorders; n++)
            {
                int x_randomBorderPoint;
                int y_randomBorderPoint;
                do
                {
                    x_randomBorderPoint = (rnd.Next() % (randomWidth + 1));
                    y_randomBorderPoint = (rnd.Next() % (randomHeight + 1));
                } while (!(map.IsBorder(x_randomBorderPoint, y_randomBorderPoint)));

                int borderDirectionHorizontal = rnd.Next() % 100;
                int borderDirectionVertical = rnd.Next() % 100;
                int borderDirectionDiagonal = rnd.Next() % 100;

                if (borderDirectionHorizontal % 2 == 0)
                    borderDirectionHorizontal = 1;
                else
                    borderDirectionHorizontal = -1;

                if (borderDirectionVertical % 2 == 0)
                    borderDirectionVertical = 1;
                else
                    borderDirectionVertical = -1;

                if (borderDirectionDiagonal % 2 == 0)
                    borderDirectionDiagonal = 1;
                else
                    borderDirectionDiagonal = -1;

                int hypotenus = (int)Math.Sqrt(Math.Pow(randomWidth, 2) + Math.Pow(randomHeight, 2));

                if (borderDirectionDiagonal == 1)
                    for (int m = 0; m <= hypotenus; m++)
                        map.SetBorder(x_randomBorderPoint + m * borderDirectionHorizontal, y_randomBorderPoint + m * borderDirectionVertical);

                else if (n % 2 == 0)
                    for (int m = 0; m <= hypotenus; m++)
                        map.SetBorder(x_randomBorderPoint, y_randomBorderPoint + m * borderDirectionVertical);

                else
                    for (int m = 0; m <= hypotenus; m++)
                        map.SetBorder(x_randomBorderPoint + m * borderDirectionHorizontal, y_randomBorderPoint);
            }

            Console.Write("\n");
            Console.Write("Frame Width,Height: ");
            Console.Write(randomWidth);
            Console.Write(",");
            Console.Write(randomHeight);
            Console.Write("\n");
        }

        static void Main(string[] args)
        {
            MapInterface map = new Map.Map();
            ZoneCounterInterface zone = new ZoneCounter.ZoneCounter();

            CreateRandomMap(map);
            zone.Init(map);

            Console.Write("AREAS: ");
            Console.Write(zone.Solve());
            Console.Write("\n");

            map.Show();

            Console.ReadKey();
        }
    }
}
