using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Fuijitsu_Chess.Main;

namespace Fuijitsu_Chess.Helpers
{
    class FileHelpers
    {
        private static int _numberOfSolutions = 1;
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
                Board.AxisX = Convert.ToInt32(input[0]);
                Board.AxisY = Convert.ToInt32(input[1]);
            }
            catch (Exception)
            {
                Board.AxisX = 8;
                Board.AxisY = 8;
            }            

        }

        public static void WriteToFile(string outPutFileName, List<Point> coordinatesToDestination, CurrentPiece chessPiece)
        {
            using (var file = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"SourceFiles\", outPutFileName ), true))
            {
                file.WriteLine(chessPiece.ChessPiece + " solution {0}:", _numberOfSolutions);
                file.WriteLine(MoveMethods.MinMoves);
                foreach (var coord in coordinatesToDestination)
                {
                    string coordsInLetter;
                    if (coord != coordinatesToDestination.Last())
                        coordsInLetter = CoordinatesHelperMethods.CoordToLetter(coord.X) + (coord.Y + 1) + ", ";
                    else coordsInLetter = CoordinatesHelperMethods.CoordToLetter(coord.X) + (coord.Y + 1);
                    file.Write(coordsInLetter);
                }
                file.WriteLine();
                file.WriteLine();              
            }
            _numberOfSolutions++;             
        }

    }
}
