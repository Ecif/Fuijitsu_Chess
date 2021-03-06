﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Fuijitsu_Chess.Helpers;

namespace Fuijitsu_Chess.Main
{
    class MoveMethods
    {
        public static int Moves = 0;
        public static int MinMoves = 0;
        public static List<Point> CoordinatesToDestination = new List<Point>();
        public static bool CancelMoves = false;
        private static void GenerateMoves(Node currentNode, List<Point> forbiddenCoords, CurrentPiece chessPiece)
        {
            var positions = PositionsHelpers.GetChessPiecePositions(chessPiece);            
            foreach (var availableMoveCoordinates in positions)
            {                          
                Point newCoords = currentNode.Coords + (Size)availableMoveCoordinates;                
                bool forbidden = forbiddenCoords.Any(forbiddenCoord => newCoords == forbiddenCoord);
                if (CancelMoves)
                {
                    if (availableMoveCoordinates.X == 7 || availableMoveCoordinates.X == -7 || availableMoveCoordinates.Y == 7 || availableMoveCoordinates.X == -7) CancelMoves = false;
                    continue;
                }
                if (forbidden)
                {
                    if (chessPiece.IsQueenRookOrBishop) CancelMoves = true;
                    continue;
                }
                if (newCoords.X >= 0 && newCoords.Y >= 0 && newCoords.X < Board.AxisX && newCoords.Y < Board.AxisY)
                {                    
                    if (currentNode.Parent != null && currentNode.Parent.Coords == newCoords) continue;
                    var childNode = new Node {Coords = newCoords, Parent = currentNode};
                    currentNode.Children.Add(childNode);
                }
            }
        }



        public static bool FindPath(string outputFileName, List<Node> source, Node to, List<Point> closedPositions, CurrentPiece chessPiece)
        {
            var nextLevel = new List<Node>();
            bool noNextLevel = false;                               
            foreach (var child in source)
            {

                GenerateMoves(child, closedPositions, chessPiece);
                if (CoordinatesHelperMethods.CheckDestinationCoords(child, to.Coords, outputFileName, chessPiece))
                {                                                
                    noNextLevel = true;
                }
                nextLevel.AddRange(child.Children);
                if (!nextLevel.Any() || to.Coords.X >= Board.AxisX || to.Coords.Y >= Board.AxisY)
                {
                    Console.WriteLine("Could not find path to specified position.");                        
                    return false;
                }
            }
            if (noNextLevel) return true;
            return FindPath(outputFileName, nextLevel, to, closedPositions, chessPiece);                                         
        }        
    }
}
