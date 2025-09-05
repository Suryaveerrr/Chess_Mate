using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : BasePiece
{
    public override List<Vector2Int> GetPossibleMoves()
    {
        var moves = new List<Vector2Int>();

        
        int[] rowDirections = { 1, -1, 0, 0, 1, 1, -1, -1 };
        int[] colDirections = { 0, 0, -1, 1, 1, -1, 1, -1 };

        for (int i = 0; i < 8; i++)
        {
            for (int j = 1; j < 8; j++)
            {
                int targetRow = row + rowDirections[i] * j;
                int targetCol = column + colDirections[i] * j;

                if (!IsWithinBoard(targetRow, targetCol)) break;

                BasePiece pieceOnTarget = PieceManager.Instance.GetPieceAt(targetRow, targetCol);

                if (pieceOnTarget == null)
                {
                    moves.Add(new Vector2Int(targetRow, targetCol));
                }
                else
                {
                    if (pieceOnTarget.pieceColor != this.pieceColor)
                    {
                        moves.Add(new Vector2Int(targetRow, targetCol));
                    }
                    break;
                }
            }
        }
        return moves;
    }
}
