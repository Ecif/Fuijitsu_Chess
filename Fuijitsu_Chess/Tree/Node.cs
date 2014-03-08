using System.Collections.Generic;
using System.Drawing;

namespace Fuijitsu_Chess.Tree
{
    public class Node
    {
        public Point Coords;
        public Node Parent;
        public List<Node> Children = new List<Node>();       
    }
}
