using UnityEngine;

public class ChessPlayerPlacementHandler : MonoBehaviour
{
    [SerializeField] public int row, column;

    private void Start()
    {
        Invoke(nameof(DelayedSnapToTile), 0.1f); // Wait for tiles to be initialized
    }

    void DelayedSnapToTile()
    {
        var tile = ChessBoardPlacementHandler.Instance.GetTile(row, column);
        if (tile != null)
        {
            transform.position = tile.transform.position;
        }
        else
        {
            Debug.LogWarning($"❌ Could not find tile for piece at ({row}, {column})");
        }
    }

    public Vector2Int GetPosition()
    {
        return new Vector2Int(row, column);
    }
}
