using System;
using System.Collections.Generic;
using System.Drawing;
using Fuijitsu_Chess.Tree;

namespace Fuijitsu_Chess
{
    class Program
    {
        static void Main(string[] args)
        {            
            List<Node> startPoint = new List<Node>();

            Node startNode = new Node
            {
                Coords = new Point {X = 0, Y = 0},
                Parent = null
            };
            startPoint.Add(startNode);

            MoveMethods.MakePath( startPoint ,new Point { X = 4, Y =5  });
            Console.WriteLine();
            Console.Write(MoveMethods.Moves + " total moves.");
            Console.ReadLine();
        }
    }
}
