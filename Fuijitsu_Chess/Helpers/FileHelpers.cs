using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuijitsu_Chess.Main;

namespace Fuijitsu_Chess.Helpers
{
    class FileHelpers
    {
        public static void GetDataFromFile(string inputFileName, Node endPoint, Node startNode, List<Point> closedPositions)
        {
            string[] input = File.ReadAllLines(Path.IsPathRooted(inputFileName) ? inputFileName : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SourceFiles\", inputFileName));
            var startingPointCoord = CoordinatesHelperMethods.LetterToCoord(input[0]);
            if (startingPointCoord != null) startNode.Coords = (Point)startingPointCoord;
            var endingPointCoord = CoordinatesHelperMethods.LetterToCoord(input[1]);
            if (endingPointCoord != null) endPoint.Coords = (Point)endingPointCoord;
            if (input[2] != null)
            {
                string[] closedCoords = input[2].Split(new[] { ",", " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                closedPositions.AddRange(from closedCoord in closedCoords let closedPosition = new Point() select (Point)CoordinatesHelperMethods.LetterToCoord(closedCoord));
            }
        }

        public static void WriteToFile(string outPutFileName, List<Point> coordinatesToDestination)
        {
            using (var file = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SourceFiles\", outPutFileName)))
            {
                file.WriteLine(MoveMethods.Moves);
                foreach (var coord in coordinatesToDestination)
                {
                    string coordsInLetter;
                    if (coord != coordinatesToDestination.Last())
                        coordsInLetter = CoordinatesHelperMethods.CoordToLetter(coord.X) + (coord.Y + 1) + ", ";
                    else coordsInLetter = CoordinatesHelperMethods.CoordToLetter(coord.X) + (coord.Y + 1);
                    file.Write(coordsInLetter);
                }
            }
                        
            Console.Write(MoveMethods.Moves + " total moves.");

            Console.WriteLine();
            foreach (var coordinate in coordinatesToDestination)
            {
                Console.Write("{0}{1} ", CoordinatesHelperMethods.CoordToLetter(coordinate.X), coordinate.Y + 1);
            }
            Console.WriteLine();
        }

    }
}
