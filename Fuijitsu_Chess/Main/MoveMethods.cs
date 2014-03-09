using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fuijitsu_Chess.Chess_pieces.Knight;
using Fuijitsu_Chess.Helpers;

namespace Fuijitsu_Chess.Main
{
    class MoveMethods
    {
        public static int Moves = 0;
        public static List<Point> CoordinatesToDestination = new List<Point>();
        private static void GenerateMoves(Node currentNode, List<Point> forbiddenCoords)
        {
            var positions = KnightPositions.Positions;
            foreach (var availableMoveCoordinates in positions)
            {
                Point newCoords = currentNode.Coords + (Size)availableMoveCoordinates;
                if (newCoords.X >= 0 && newCoords.Y >= 0 && newCoords.X < 8 && newCoords.Y < 8)
                {
                    bool forbidden = forbiddenCoords.Any(forbiddenCoord => newCoords == forbiddenCoord);
                    // no point in going back where we start
                    if (currentNode.Parent != null && currentNode.Parent.Coords == newCoords || forbidden) continue;                    
                    else
                    {
                        var n = new Node() { Coords = newCoords, Parent = currentNode };
                        currentNode.Children.Add(n);
                    }
                }
            }
        }

        public static Node MakePath(List<Node> source, Node to, List<Point> closedPositions)
        {
            var nextLevel = new List<Node>();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0}{1} is being found....", CoordinatesHelperMethods.CoordToLetter(to.Coords.X), to.Coords.Y + 1);
            bool newnode = true;
            Point node = new Point();
            foreach (var child in source)
            {

                GenerateMoves(child, closedPositions);
                if (child.Parent != null)
                {
                    if (node.X != child.Parent.Coords.X && node.Y != child.Parent.Coords.Y) newnode = true;
                    if (newnode)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("{0}{1} children are:  ", CoordinatesHelperMethods.CoordToLetter(child.Parent.Coords.X), child.Parent.Coords.Y + 1);
                        newnode = false;
                        node = child.Parent.Coords;
                    }
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("{0}{1} ", CoordinatesHelperMethods.CoordToLetter(child.Coords.X), child.Coords.Y + 1);
                if (CoordinatesHelperMethods.CheckDestinationCoords(child, to.Coords))
                {
                    Console.WriteLine();
                    Console.Write(Moves + " total moves.");
                    CoordinatesToDestination.Reverse();
                    Console.WriteLine();
                    foreach (var coordinate in CoordinatesToDestination)
                    {                        
                        Console.Write("{0}{1} ", CoordinatesHelperMethods.CoordToLetter(coordinate.X),coordinate.Y + 1);
                    }                    
                    return child;
                }                                  
                nextLevel.AddRange(child.Children);
                
            }
            return MakePath(nextLevel, to, closedPositions);
        }

        
    }
}
