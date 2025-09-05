using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : BasePiece
{
    public override List<Vector2Int> GetPossibleMoves()
    {
        var moves = new List<Vector2Int>();

        
        int[] rowOffsets = { 1, -1, 0, 0, 1, 1, -1, -1 };
        int[] colOffsets = { 0, 0, -1, 1, 1, -1, 1, -1 };

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
