using System.Collections.Generic;
using System.Drawing;
using Fuijitsu_Chess.Chess_pieces;

namespace Fuijitsu_Chess.Helpers
{
    class PositionsHelpers
    {
        public static List<Point> GetChessPiecePositions(CurrentPiece chessPiece)
        {
            if (chessPiece.ChessPiece.ToUpper().Contains("KNIGHT"))return Knight.Positions;
            if (chessPiece.ChessPiece.ToUpper().Contains("KING")) return King.Positions; 
            if (chessPiece.ChessPiece.ToUpper().Contains("BISHOP"))
            {
                chessPiece.IsQueenRookOrBishop = true;
                return Bishop.Positions;
            }           
            
            if (chessPiece.ChessPiece.ToUpper().Contains("ROOK"))
            {
                chessPiece.IsQueenRookOrBishop = true;
                return Rook.Positions;
            }
            if (chessPiece.ChessPiece.ToUpper().Contains("QUEEN"))
            {                
                chessPiece.IsQueenRookOrBishop = true;
                return Queen.Positions;
            }
            return Knight.Positions;
        }
    }
}
