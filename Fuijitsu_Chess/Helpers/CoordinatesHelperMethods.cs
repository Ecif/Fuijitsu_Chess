
using System.Drawing;
using Fuijitsu_Chess.Tree;

namespace Fuijitsu_Chess.Helpers
{
    public static class CoordinatesHelperMethods
    {
        public static int LetterToCoord(string letterString)
        {
            if (letterString.Contains("A")) return 0;
            else if (letterString.Contains("B")) return 1;
            else if (letterString.Contains("C")) return 2;
            else if (letterString.Contains("D")) return 3;
            else if (letterString.Contains("E")) return 4;
            else if (letterString.Contains("F")) return 5;
            else if (letterString.Contains("G")) return 6;
            else if (letterString.Contains("H")) return 7;
            return -101;            
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
                var currentNode = child;
                do
                {
                    var parent = currentNode.Parent;
                    currentNode = parent;
                    MoveMethods.Moves++;
                } while (currentNode.Parent != null);
                return true;
            }
            return false;
        }
    }
}
