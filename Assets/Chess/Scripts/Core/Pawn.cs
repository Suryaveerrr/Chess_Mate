using System.Collections.Generic;
using UnityEngine;

public class Pawn : BasePiece
{
    public override List<Vector2Int> GetPossibleMoves()
    {
        var moves = new List<Vector2Int>();

        
        int direction = (pieceColor == PieceColor.White) ? -1 : 1;

        // --- Forward Movement ---
        int oneStepForward = row + direction;
        if (IsWithinBoard(oneStepForward, column) && PieceManager.Instance.GetPieceAt(oneStepForward, column) == null)
        {
            moves.Add(new Vector2Int(oneStepForward, column));

            // --- Initial Two-Step Move ---
            
            bool isStartingRow = (pieceColor == PieceColor.White && row == 6) || (pieceColor == PieceColor.Black && row == 1);
            int twoStepsForward = row + (2 * direction);
            if (isStartingRow && IsWithinBoard(twoStepsForward, column) && PieceManager.Instance.GetPieceAt(twoStepsForward, column) == null)
            {
                moves.Add(new Vector2Int(twoStepsForward, column));
            }
        }

        // --- Diagonal Captures ---
        int[] captureCols = { column - 1, column + 1 };
        foreach (int captureCol in captureCols)
        {
            if (IsWithinBoard(oneStepForward, captureCol))
            {
                BasePiece pieceOnTarget = PieceManager.Instance.GetPieceAt(oneStepForward, captureCol);
                if (pieceOnTarget != null && pieceOnTarget.pieceColor != this.pieceColor)
                {
                    moves.Add(new Vector2Int(oneStepForward, captureCol));
                }
            }
        }

        return moves;
    }
}