using System.Collections.Generic;
using UnityEngine;

public class King : ChessPiece
{
    public override List<Vector2Int> GetLegalMoves(ChessPiece[,] board, Vector2Int pos)
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,
            Vector2Int.up + Vector2Int.left, Vector2Int.up + Vector2Int.right,
            Vector2Int.down + Vector2Int.left, Vector2Int.down + Vector2Int.right
        };

        foreach (var dir in directions)
        {
            int r = pos.x + dir.x;
            int c = pos.y + dir.y;

            if (!ChessBoardPlacementHandler.Instance.IsInBounds(r, c)) continue;

            ChessPiece target = board[r, c];
            if (target == null || target.isWhite != this.isWhite)
                moves.Add(new Vector2Int(r, c));
        }

        return moves;
    }
}