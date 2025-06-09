using System.Collections.Generic;
using UnityEngine;

public class Rook : Queen
{
    public override List<Vector2Int> GetLegalMoves(ChessPiece[,] board, Vector2Int pos)
    {
        return GetSlidingMoves(board, pos, new Vector2Int[] {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        });
    }
}