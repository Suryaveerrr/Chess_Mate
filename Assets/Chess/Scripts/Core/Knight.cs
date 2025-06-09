using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetLegalMoves(ChessPiece[,] board, Vector2Int pos)
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int[] deltas = {
            new Vector2Int(2, 1), new Vector2Int(2, -1), new Vector2Int(-2, 1), new Vector2Int(-2, -1),
            new Vector2Int(1, 2), new Vector2Int(1, -2), new Vector2Int(-1, 2), new Vector2Int(-1, -2)
        };

        foreach (var delta in deltas)
        {
            int r = pos.x + delta.x;
            int c = pos.y + delta.y;

            if (!ChessBoardPlacementHandler.Instance.IsInBounds(r, c)) continue;

            var piece = board[r, c];
            if (piece == null || piece.isWhite != this.isWhite)
                moves.Add(new Vector2Int(r, c));
        }

        return moves;
    }
}