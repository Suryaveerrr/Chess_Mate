using System.Collections.Generic; //Most annoying part
using UnityEngine;

public class ChessBoardPlacementHandler : MonoBehaviour
{
    public static ChessBoardPlacementHandler Instance;

    [Header("Highlight Prefabs")]
    public GameObject redSquarePrefab;
    public GameObject greenDotPrefab;
    public GameObject redCirclePrefab;

    public GameObject[,] tiles = new GameObject[8, 8];
    private List<GameObject> currentHighlights = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        AutoInitializeTilesFromRows();

        
        for (int r = 0; r < 8; r++)
            for (int c = 0; c < 8; c++)
                if (tiles[r, c] == null)
                    Debug.LogWarning($" Tile missing at ({r},{c})");
    }

    
    public void AutoInitializeTilesFromRows()
    {
        for (int row = 0; row < 8; row++)
        {
            string rowName = $"Row ({row})";
            GameObject rowObj = GameObject.Find(rowName);

            if (rowObj == null)
            {
                Debug.LogError($" Cannot find GameObject: {rowName}");
                continue;
            }

            for (int col = 0; col < 8; col++)
            {
                if (col >= rowObj.transform.childCount)
                {
                    Debug.LogWarning($" {rowName} is missing a child at index {col}");
                    continue;
                }

                GameObject tile = rowObj.transform.GetChild(col).gameObject;
                tiles[row, col] = tile;
            }
        }

        Debug.Log(" Chessboard tiles initialized successfully.");
    }

    public bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    public GameObject GetTile(int row, int col)
    {
        if (IsInBounds(row, col))
            return tiles[row, col];
        return null;
    }

    public void Highlight(int row, int col)
    {
        GameObject tile = GetTile(row, col);
        if (tile == null)
        {
            Debug.LogWarning($" Tile at ({row}, {col}) is null (Highlight)");
            return;
        }

        GameObject prefabToUse = BoardManager.Instance.boardState[row, col] != null
            ? redSquarePrefab
            : greenDotPrefab;

        GameObject marker = Instantiate(prefabToUse, tile.transform);
        marker.transform.localPosition = Vector3.zero;
        currentHighlights.Add(marker);
    }

    public void PlaceRedCircle(int row, int col)
    {
        var tile = GetTile(row, col);
        if (tile == null)
        {
            Debug.LogWarning($" RedCircle: tile is NULL at ({row},{col})");
            return;
        }

        GameObject red = Instantiate(redCirclePrefab, tile.transform);
        red.transform.localPosition = Vector3.zero;
        currentHighlights.Add(red);
    }


    public void ClearHighlights()
    {
        foreach (var item in currentHighlights)
        {
            if (item != null)
                Destroy(item);
        }
        currentHighlights.Clear();
    }
}
