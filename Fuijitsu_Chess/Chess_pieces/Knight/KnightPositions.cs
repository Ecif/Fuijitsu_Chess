using System.Collections.Generic;
using System.Drawing;

namespace Fuijitsu_Chess.Chess_pieces.Knight
{
    public static class KnightPositions
    {
        public static readonly List<Point> Positions = new List<Point>()
        {
            new Point() {X = -1, Y = -2},
            new Point() {X = -2, Y = -1},
            new Point() {X = -2, Y = 1},
            new Point() {X = -1, Y = 2},
            new Point() {X = 1, Y = 2},
            new Point() {X = 2, Y = 1},
            new Point() {X = 2, Y = -1},
            new Point() {X = 1, Y = -2}
        };
    }
}
