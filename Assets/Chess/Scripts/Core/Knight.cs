using System.Collections.Generic;
using UnityEngine;

public class Knight : BasePiece
{
    public override List<Vector2Int> GetPossibleMoves()
    {
        var moves = new List<Vector2Int>();

        int[] rowOffsets = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] colOffsets = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int i = 0; i < 8; i++)
        {
            int targetRow = row + rowOffsets[i];
            int targetCol = column + colOffsets[i];

            if (IsWithinBoard(targetRow, targetCol))
            {
                BasePiece pieceOnTarget = PieceManager.Instance.GetPieceAt(targetRow, targetCol);
                if (pieceOnTarget == null || pieceOnTarget.pieceColor != this.pieceColor)
                {
                    moves.Add(new Vector2Int(targetRow, targetCol));
                }
            }
        }
        return moves;
    }
}