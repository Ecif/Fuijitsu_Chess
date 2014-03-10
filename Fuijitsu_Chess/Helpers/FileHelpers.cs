using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuijitsu_Chess.Chess_pieces;
using Fuijitsu_Chess.Main;

namespace Fuijitsu_Chess.Helpers
{
    class FileHelpers
    {
        private static int _numberOfOutput = 1;
        public static void GetDataFromFile(string inputFileName, Node endPoint, Node startNode, List<Point> closedPositions, CurrentPiece piece)
        {
            string[] input = File.ReadAllLines(Path.IsPathRooted(inputFileName) ? inputFileName : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SourceFiles\", inputFileName));
            var startingPointCoord = CoordinatesHelperMethods.LetterToCoord(input[2]);
            if (startingPointCoord != null) startNode.Coords = (Point)startingPointCoord;
            var endingPointCoord = CoordinatesHelperMethods.LetterToCoord(input[3]);
            if (endingPointCoord != null) endPoint.Coords = (Point)endingPointCoord;
            if (input[4] != null)
            {                
                string[] closedCoords = input[4].Split(new[] { ",", " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                closedPositions.AddRange(from closedCoord in closedCoords let closedPosition = new Point()
                                         let letterToCoord = CoordinatesHelperMethods.LetterToCoord(closedCoord) where letterToCoord != null select (Point)letterToCoord);

            }
            piece.ChessPiece = input[5].Contains("-") ? "Knight" : input[5];
            try
            {
                Board.AxisX = Convert.ToInt32(input[1]);
                Board.AxisY = Convert.ToInt32(input[1]);
            }
            catch (Exception)
            {
                Board.AxisX = 8;
                Board.AxisY = 8;
            }
            Console.WriteLine(piece.ChessPiece);

        }

        public static void WriteToFile(string outPutFileName, List<Point> coordinatesToDestination)
        {
            using (var file = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SourceFiles\", _numberOfOutput + outPutFileName )))
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
                _numberOfOutput++;
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
