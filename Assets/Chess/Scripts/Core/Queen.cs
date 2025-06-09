using System.Collections.Generic;
using UnityEngine;


public class Queen : ChessPiece 
{
    public override List<Vector2Int> GetLegalMoves(ChessPiece[,] board, Vector2Int currentPos)
    {
        return GetSlidingMoves(board, currentPos, new Vector2Int[] {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right,
            Vector2Int.up + Vector2Int.left, Vector2Int.up + Vector2Int.right,
            Vector2Int.down + Vector2Int.left, Vector2Int.down + Vector2Int.right
        });
    }

    protected List<Vector2Int> GetSlidingMoves(ChessPiece[,] board, Vector2Int pos, Vector2Int[] directions)
    {
        List<Vector2Int> moves = new List<Vector2Int>();

        foreach (var dir in directions)
        {
            int r = pos.x + dir.x;
            int c = pos.y + dir.y;

            while (ChessBoardPlacementHandler.Instance.IsInBounds(r, c))
            {
                var piece = board[r, c];
                if (piece == null)
                    moves.Add(new Vector2Int(r, c));
                else
                {
                    if (piece.isWhite != this.isWhite)
                        moves.Add(new Vector2Int(r, c));
                    break;
                }

                r += dir.x;
                c += dir.y;
            }
        }

        return moves;
    }
}