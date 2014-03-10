using System.Collections.Generic;
using System.Drawing;

namespace Fuijitsu_Chess.Chess_pieces
{
    public static class Bishop
    {
        public static readonly List<Point> Positions = new List<Point>
        {
            // up-right diagonal movement
            new Point {X = 1, Y = 1},
            new Point {X = 2, Y = 2},
            new Point {X = 3, Y = 3},
            new Point {X = 4, Y = 4},
            new Point {X = 5, Y = 5},
            new Point {X = 6, Y = 6},
            new Point {X = 7, Y = 7},
            // down-left diagonal movement
            new Point {X = -1, Y = -1},
            new Point {X = -2, Y = -2},
            new Point {X = -3, Y = -3},
            new Point {X = -4, Y = -4},
            new Point {X = -5, Y = -5},
            new Point {X = -6, Y = -6},
            new Point {X = -7, Y = -7},
            // down-right diagonal movement
            new Point {X = 1, Y = -1},
            new Point {X = 2, Y = -2},
            new Point {X = 3, Y = -3},
            new Point {X = 4, Y = -4},
            new Point {X = 5, Y = -5},
            new Point {X = 6, Y = -6},
            new Point {X = 7, Y = -7},
            // up-left diagonal movement
            new Point {X = -1, Y = 1},
            new Point {X = -2, Y = 2},
            new Point {X = -3, Y = 3},
            new Point {X = -4, Y = 4},
            new Point {X = -5, Y = 5},
            new Point {X = -6, Y = 6},
            new Point {X = -7, Y = 7}
        };
    }
}
