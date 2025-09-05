using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public static PieceManager Instance { get; private set; }
    public BasePiece[,] board = new BasePiece[8, 8];
    private BasePiece selectedPiece;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        SetupBoard();
    }

    private void SetupBoard()
    {
        BasePiece[] pieces = FindObjectsOfType<BasePiece>();
        foreach (BasePiece piece in pieces)
        {
            if (piece.row >= 0 && piece.row < 8 && piece.column >= 0 && piece.column < 8)
            {
                board[piece.row, piece.column] = piece;
            }
        }
    }

    public void SelectPiece(BasePiece piece)
    {
        selectedPiece = piece;
        ChessBoardPlacementHandler.Instance.ClearHighlights();
        List<Vector2Int> possibleMoves = selectedPiece.GetPossibleMoves();
        HighlightMoves(possibleMoves);
    }

    private void HighlightMoves(List<Vector2Int> moves)
    {
        foreach (Vector2Int move in moves)
        {
            BasePiece pieceAtTarget = GetPieceAt(move.x, move.y);

            if (pieceAtTarget != null && pieceAtTarget.pieceColor != selectedPiece.pieceColor)
            {
                
                ChessBoardPlacementHandler.Instance.HighlightCapture(move.x, move.y);
            }
            else
            {
               
                ChessBoardPlacementHandler.Instance.HighlightMove(move.x, move.y);
            }
        }
    }

    public BasePiece GetPieceAt(int row, int col)
    {
        if (row < 0 || row >= 8 || col < 0 || col >= 8) return null;
        return board[row, col];
    }
}