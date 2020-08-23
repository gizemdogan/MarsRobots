using MarsRobots.Helpers;
using MarsRobots.Models;
using System;
using System.Collections.Generic;

namespace MarsRobots
{
    class Program
    {
        static void Main(string[] args)
        {
            bool hasError = false;

            int rectangleXSize = 0, rectangleYSize = 0;
            int robotCoordinateX = 0, robotCoordinateY = 0;
            char robotCardinalPoint = Char.MinValue;
            string robotCommandCharacters = string.Empty;

            do
            {
                Console.WriteLine("Yüzey boyutlarını aralarında bir boşluk olacak şekilde giriniz");
                string rectangleSizeInput = Console.ReadLine();
                string[] rectangleSizeList = rectangleSizeInput.Split(' ');

                if (rectangleSizeList.Length < 2)
                {
                    hasError = true;
                    Console.WriteLine("Hatalı giriş yaptınız!");
                }
                else if (!int.TryParse(rectangleSizeList[0], out rectangleXSize))
                {
                    hasError = true;
                    Console.WriteLine("Yatay(X) boyutu alınamadı.");
                }
                else if (!int.TryParse(rectangleSizeList[1], out rectangleYSize))
                {
                    hasError = true;
                    Console.WriteLine("Dikey(Y) boyutu alınamadı.");
                }
                else
                {
                    hasError = false;
                }

            } while (hasError);


            Rectangle rectangle = new Rectangle
            {
                CoordinateXSize = rectangleXSize,
                CoordinateYSize = rectangleYSize
            };


            List<RobotBase> robotList = new List<RobotBase>();

            for (int i = 1; i <= Constants.BusinessConstants.RobotCount; i++)
            {
                do
                {
                    Console.WriteLine("{0}. robotun başlangıç konumunu ve yönünü giriniz [N:North, S:South, E:East, W:West]", i);
                    string robotPropertiesInput = Console.ReadLine();
                    string[] robotPropertiesList = robotPropertiesInput.Split(' ');

                    if (robotPropertiesList.Length < 3)
                    {
                        hasError = true;
                        Console.WriteLine("Hatalı giriş yaptınız, kontrol ediniz!");
                    }
                    else if (!int.TryParse(robotPropertiesList[0], out robotCoordinateX))
                    {
                        hasError = true;
                        Console.WriteLine("{0}. robotunun X koordinatı alınamadı.", i);
                    }
                    else if (!int.TryParse(robotPropertiesList[1], out robotCoordinateY))
                    {
                        hasError = true;
                        Console.WriteLine("{0}. robotunun Y koordinatı alınamadı.", i);
                    }
                    else if (!RobotHelper.IsValidCardinalPoint(robotPropertiesList[2], out robotCardinalPoint))
                    {
                        hasError = true;
                        Console.WriteLine("{0}. robotunun yönünü yanlış girdiniz. ", i);
                    }
                    else
                    {
                        hasError = false;
                    }

                } while (hasError);


                do
                {
                    Console.WriteLine("{0}. robotu yönlendirecek harf katarını giriniz. [L:Left, R:Right , M:Move]", i);
                    robotCommandCharacters = Console.ReadLine();

                    if (!RobotHelper.IsValidCommandCharacters(robotCommandCharacters))
                    {
                        hasError = true;
                        Console.WriteLine("Hatalı giriş yaptınız.");
                    }
                    else
                    {
                        hasError = false;
                    }

                } while (hasError);


                RobotBase robot = new Robot(rectangle)
                {
                    CoordinateX = robotCoordinateX,
                    CoordinateY = robotCoordinateY,
                    CardinalPoint = robotCardinalPoint,
                    CommandCharacters = robotCommandCharacters
                };

                robotList.Add(robot);
            }

            Console.WriteLine();

            foreach (var robot in robotList)
            {
                robot.ControlRobot();
                RobotHelper.WriteRobotProperties(robot);
            }

            Console.ReadLine();
        }
    }
}