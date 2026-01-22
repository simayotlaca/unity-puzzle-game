using UnityEngine;

namespace PuzzleGame.Grid
{
    public class GridManager : MonoBehaviour
    {
        [Header("Grid Settings")]
        [SerializeField] private int gridWidth = 8;
        [SerializeField] private int gridHeight = 8;
        [SerializeField] private float tileSize = 1f;

        [Header("Tile Prefab")]
        [SerializeField] private GameObject tilePrefab;

        private Tile[,] grid;
        public void InitializeGrid()
        {
            grid = new Tile[gridWidth, gridHeight];

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    SpawnTile(x, y);
                }
            }

            Debug.Log($"Grid initialized: {gridWidth}x{gridHeight}");
        }

        private void SpawnTile(int x, int y)
        {
            if (tilePrefab == null)
            {
                Debug.LogError("Tile prefab is not assigned!");
                return;
            }

            Vector3 position = new Vector3(x * tileSize, y * tileSize, 0);
            GameObject tileObject = Instantiate(tilePrefab, position, Quaternion.identity, transform);
            tileObject.name = $"Tile ({x}, {y})";

            Tile tile = tileObject.GetComponent<Tile>();
            if (tile != null)
            {
                tile.Initialize(x, y, Random.Range(0, 5)); // Random tile type (0-4)
                grid[x, y] = tile;
            }
        }

        public Tile GetTile(int x, int y)
        {
            if (IsValidPosition(x, y))
            {
                return grid[x, y];
            }
            return null;
        }

        public void SwapTiles(Tile tile1, Tile tile2)
        {
            if (tile1 == null || tile2 == null) return;
            int tempX = tile1.GridX;
            int tempY = tile1.GridY;

            grid[tile1.GridX, tile1.GridY] = tile2;
            grid[tile2.GridX, tile2.GridY] = tile1;

            tile1.SetGridPosition(tile2.GridX, tile2.GridY);
            tile2.SetGridPosition(tempX, tempY);

        }
        public bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < gridWidth && y >= 0 && y < gridHeight;
        }

        public int GetWidth() => gridWidth;
        public int GetHeight() => gridHeight;
    }
}
