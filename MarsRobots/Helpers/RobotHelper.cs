using MarsRobots.Models;
using System;

namespace MarsRobots.Helpers
{
    public class RobotHelper
    {
        public static bool IsValidCommandCharacters(string robotCommandCharacters)
        {
            for (int i = 0; i < robotCommandCharacters.Length; i++)
            {
                if (robotCommandCharacters[i] != 'L'
                    && robotCommandCharacters[i] != 'R'
                    && robotCommandCharacters[i] != 'M')
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsValidCardinalPoint(string robotCardinalPointProperty, out char robotCardinalPoint)
        {
            robotCardinalPoint = string.IsNullOrEmpty(robotCardinalPointProperty) ? Char.MinValue : robotCardinalPointProperty[0];

            if (robotCardinalPointProperty.Equals("N")
                || robotCardinalPointProperty.Equals("S")
                || robotCardinalPointProperty.Equals("E")
                || robotCardinalPointProperty.Equals("W"))
            {
                return true;
            }
            return false;
        }

        public static void WriteRobotProperties(RobotBase robot)
        {
            Console.WriteLine(robot.CoordinateX + " " + 
                              robot.CoordinateY + " " + 
                              robot.CardinalPoint);
        }
    }
}