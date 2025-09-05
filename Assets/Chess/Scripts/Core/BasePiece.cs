using System.Collections.Generic;
using UnityEngine;
using Chess.Scripts.Core; 

public enum PieceColor
{
    White,
    Black
}

[RequireComponent(typeof(ChessPlayerPlacementHandler))]
public abstract class BasePiece : MonoBehaviour
{
    [HideInInspector] public int row;
    [HideInInspector] public int column;
    public PieceColor pieceColor;

    private void Awake()
    {
        var placementHandler = GetComponent<ChessPlayerPlacementHandler>();
        if (placementHandler != null)
        {
            this.row = placementHandler.row;
            this.column = placementHandler.column;
        }
        else
        {
            Debug.LogError($"Piece '{gameObject.name}' is missing a ChessPlayerPlacementHandler script!");
        }
    }

    public abstract List<Vector2Int> GetPossibleMoves();

    private void OnMouseDown()
    {
        PieceManager.Instance.SelectPiece(this);
    }

    protected bool IsWithinBoard(int r, int c)
    {
        return r >= 0 && r < 8 && c >= 0 && c < 8;
    }
}