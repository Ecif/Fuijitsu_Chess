﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Fuijitsu_Chess.Main;
using Fuijitsu_Chess.Helpers;


namespace Fuijitsu_Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            var startingPoint = new List<Node>();            
            var endPoint = new Node();
            var closedPositions = new List<Point>();
            var chessPiece = new CurrentPiece();
            string outputFileName = null;                            
            try
            {
                string inputFileName = args[0];
                outputFileName = args[1];
                if (inputFileName != null)
                {
                    var startNode = new Node();
                    FileHelpers.GetDataFromFile(inputFileName, endPoint, startNode, closedPositions, chessPiece);                                          
                    startingPoint.Add(startNode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Missing or false parameters!");
                Console.WriteLine(e.Message);                    
            }
            if (MoveMethods.FindPath(outputFileName, startingPoint, endPoint, closedPositions, chessPiece))
                Console.WriteLine("Paths successfully found.");           
            Console.WriteLine("Press enter to terminate ... ");
            Console.ReadLine();   
                      
        }
    }
}
