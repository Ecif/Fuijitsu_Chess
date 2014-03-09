
using System;
using System.Drawing;
using Fuijitsu_Chess.Main;

namespace Fuijitsu_Chess.Helpers
{
    public static class CoordinatesHelperMethods
    {
        public static Point? LetterToCoord(string letterString)
        {
            var coordinates = new Point();

            try
            {
                if (letterString.Contains("A")) coordinates.X = 0;
                else if (letterString.Contains("B")) coordinates.X = 1;
                else if (letterString.Contains("C")) coordinates.X = 2;
                else if (letterString.Contains("D")) coordinates.X = 3;
                else if (letterString.Contains("E")) coordinates.X = 4;
                else if (letterString.Contains("F")) coordinates.X = 5;
                else if (letterString.Contains("G")) coordinates.X = 6;
                else if (letterString.Contains("H")) coordinates.X = 7;
                else return null;
                coordinates.Y = Convert.ToInt32(letterString.Substring(1, 1)) - 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong data input in file.");
                Console.WriteLine(e.Message);
            }            
            return coordinates;         
        }
        public static string CoordToLetter(int i)
        {
            string letter;
            switch (i)
            {
                case 0:
                    letter = "A";
                    break;
                case 1:
                    letter = "B";
                    break;
                case 2:
                    letter = "C";
                    break;
                case 3:
                    letter = "D";
                    break;
                case 4:
                    letter = "E";
                    break;
                case 5:
                    letter = "F";
                    break;
                case 6:
                    letter = "G";
                    break;
                case 7:
                    letter = "H";
                    break;

                default:
                    letter = "ERROR";
                    break;
            }
            return letter;
        }

        public static bool CheckDestinationCoords(Node child, Point to)
        {
            if (child.Coords == to)
            {
                Console.WriteLine();
                var currentNode = child;
                do
                {
                    var parent = currentNode.Parent;
                    MoveMethods.CoordinatesToDestination.Add(currentNode.Coords);
                    currentNode = parent;                    
                    MoveMethods.Moves++;
                } while (currentNode.Parent != null);
                return true;
            }
            return false;
        }
    }
}
