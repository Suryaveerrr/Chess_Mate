using System.Collections.Generic;
using UnityEngine;

public abstract class ChessPiece : MonoBehaviour
{
    public bool isWhite;
    private ChessPlayerPlacementHandler placement;

    private void Start()
    {
        placement = GetComponent<ChessPlayerPlacementHandler>();
    }

    

    private void OnMouseDown()
    {
        if (BoardManager.Instance == null || ChessBoardPlacementHandler.Instance == null)
            return;

        Vector2Int pos = GetComponent<ChessPlayerPlacementHandler>().GetPosition();

        ChessBoardPlacementHandler.Instance.ClearHighlights();
        ChessBoardPlacementHandler.Instance.PlaceRedCircle(pos.x, pos.y);

        List<Vector2Int> moves = GetLegalMoves(BoardManager.Instance.boardState, pos);

        foreach (var move in moves)
        {
            ChessBoardPlacementHandler.Instance.Highlight(move.x, move.y);
        }
    }

    public abstract List<Vector2Int> GetLegalMoves(ChessPiece[,] board, Vector2Int currentPos);
}