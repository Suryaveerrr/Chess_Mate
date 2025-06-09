using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;

    public ChessPiece[,] boardState = new ChessPiece[8, 8];

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        InitializeBoardState();
    }

    private void InitializeBoardState()
    {
        ChessPiece[] allPieces = FindObjectsOfType<ChessPiece>();

        Debug.Log("Piece Found " + allPieces.Length + " pieces in scene.");

        foreach (ChessPiece piece in allPieces)
        {
            ChessPlayerPlacementHandler placement = piece.GetComponent<ChessPlayerPlacementHandler>();
            if (placement != null)
            {
                int row = placement.row;
                int col = placement.column;

                if (row >= 0 && row < 8 && col >= 0 && col < 8)
                {
                    boardState[row, col] = piece;
                    Debug.Log($" Placed {piece.gameObject.name} at ({row}, {col})");
                }
                else
                {
                    Debug.LogWarning($" Piece {piece.name} has invalid position: ({row}, {col})");
                }
            }
            else
            {
                Debug.LogWarning($" Missing ChessPlayerPlacementHandler on {piece.name}");
            }
        }

        Debug.Log(" Board initialized successfully.");
    }

    // Optional: For moving pieces later
    public void UpdatePiecePosition(ChessPiece piece, int newRow, int newCol)
    {
        ClearPieceFromBoard(piece);
        boardState[newRow, newCol] = piece;
    }

    public void ClearPieceFromBoard(ChessPiece piece)
    {
        for (int r = 0; r < 8; r++)
        {
            for (int c = 0; c < 8; c++)
            {
                if (boardState[r, c] == piece)
                {
                    boardState[r, c] = null;
                    return;
                }
            }
        }
    }
}
