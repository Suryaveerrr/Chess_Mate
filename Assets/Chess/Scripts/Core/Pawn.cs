using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetLegalMoves(ChessPiece[,] board, Vector2Int pos)
    {
        List<Vector2Int> moves = new List<Vector2Int>();
        int dir = isWhite ? -1 : 1; // because black is row 1 moving to 2, white is 6 -> 5
        int startRow = isWhite ? 6 : 1;

        int forward1 = pos.x + dir;

        // Forward 1 step
        if (ChessBoardPlacementHandler.Instance.IsInBounds(forward1, pos.y) && board[forward1, pos.y] == null)
        {
            moves.Add(new Vector2Int(forward1, pos.y));

            // Forward 2 steps from start row
            int forward2 = pos.x + 2 * dir;
            if (pos.x == startRow && ChessBoardPlacementHandler.Instance.IsInBounds(forward2, pos.y) && board[forward2, pos.y] == null)
            {
                moves.Add(new Vector2Int(forward2, pos.y));
            }
        }

        // Diagonal captures
        foreach (int offset in new int[] { -1, 1 })
        {
            int col = pos.y + offset;
            if (!ChessBoardPlacementHandler.Instance.IsInBounds(forward1, col)) continue;

            ChessPiece target = board[forward1, col];
            if (target != null && target.isWhite != this.isWhite)
            {
                moves.Add(new Vector2Int(forward1, col));
            }
        }

        Debug.Log($"{this.name} at {pos.x},{pos.y} generated {moves.Count} pawn moves.");
        return moves;
    }
}
