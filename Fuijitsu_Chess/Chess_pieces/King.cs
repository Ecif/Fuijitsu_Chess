using System.Collections.Generic;
using System.Drawing;

namespace Fuijitsu_Chess.Chess_pieces
{
    public static class King
    {
        public static readonly List<Point> Positions = new List<Point>
        {
            new Point {X = 1, Y = 0},
            new Point {X = 1, Y = -1},
            new Point {X = 0, Y = -1},
            new Point {X = -1, Y = -1},
            new Point {X = -1, Y = 0},
            new Point {X = -1, Y = 1},
            new Point {X = 0, Y = 1},
            new Point {X = 1, Y = 1}
        };
    }
}
