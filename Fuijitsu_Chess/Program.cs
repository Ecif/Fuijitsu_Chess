using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            do
            {
                Console.WriteLine("Please enter file name(e.g 'source') where data is read from:");
                string inputFileName = Console.ReadLine();
                try
                {
                    if (inputFileName != null)
                    {
                        var startNode = new Node();
                        GetInputData.GetDataFromFile(inputFileName, endPoint, startNode, closedPositions);                                                                       
                        startingPoint.Add(startNode);                        
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);                    

                } 
            } while (startingPoint.Count < 1);
            foreach (var pos in closedPositions)
            {
                Console.WriteLine(pos);
            }
           // MoveMethods.MakePath(startingPoint, endPoint, closedPositions);           
            Console.ReadLine();
        }


    }
}
