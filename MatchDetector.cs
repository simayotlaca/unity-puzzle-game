using System.Collections.Generic;
using UnityEngine;

namespace PuzzleGame.Grid
{
    /// <summary>
    /// Detects tile matches (3 or more in a row) horizontally and vertically
    /// </summary>
    public class MatchDetector : MonoBehaviour
    {
        [SerializeField] private GridManager gridManager;
        [SerializeField] private int minMatchLength = 3;

        /// <summary>
        /// Scans entire grid for matches
        /// </summary>
        public List<Tile> FindAllMatches()
        {
            HashSet<Tile> matchedTiles = new HashSet<Tile>();

            // Check horizontal matches
            for (int y = 0; y < gridManager.GetHeight(); y++)
            {
                for (int x = 0; x < gridManager.GetWidth(); x++)
                {
                    List<Tile> horizontalMatch = CheckHorizontalMatch(x, y);
                    if (horizontalMatch.Count >= minMatchLength)
                    {
                        matchedTiles.UnionWith(horizontalMatch);
                    }
                }
            }

            // Check vertical matches
            for (int x = 0; x < gridManager.GetWidth(); x++)
            {
                for (int y = 0; y < gridManager.GetHeight(); y++)
                {
                    List<Tile> verticalMatch = CheckVerticalMatch(x, y);
                    if (verticalMatch.Count >= minMatchLength)
                    {
                        matchedTiles.UnionWith(verticalMatch);
                    }
                }
            }

            return new List<Tile>(matchedTiles);
        }

        /// <summary>
        /// Checks for horizontal matches starting from given position
        /// </summary>
        private List<Tile> CheckHorizontalMatch(int startX, int startY)
        {
            List<Tile> matches = new List<Tile>();
            Tile startTile = gridManager.GetTile(startX, startY);

            if (startTile == null) return matches;

            matches.Add(startTile);
            int tileType = startTile.TileType;

            // Check right
            for (int x = startX + 1; x < gridManager.GetWidth(); x++)
            {
                Tile tile = gridManager.GetTile(x, startY);
                if (tile != null && tile.TileType == tileType)
                {
                    matches.Add(tile);
                }
                else
                {
                    break;
                }
            }

            return matches.Count >= minMatchLength ? matches : new List<Tile>();
        }

        /// <summary>
        /// Checks for vertical matches starting from given position
        /// </summary>
        private List<Tile> CheckVerticalMatch(int startX, int startY)
        {
            List<Tile> matches = new List<Tile>();
            Tile startTile = gridManager.GetTile(startX, startY);

            if (startTile == null) return matches;

            matches.Add(startTile);
            int tileType = startTile.TileType;

            // Check up
            for (int y = startY + 1; y < gridManager.GetHeight(); y++)
            {
                Tile tile = gridManager.GetTile(startX, y);
                if (tile != null && tile.TileType == tileType)
                {
                    matches.Add(tile);
                }
                else
                {
                    break;
                }
            }

            return matches.Count >= minMatchLength ? matches : new List<Tile>();
        }

        /// <summary>
        /// Checks if a specific tile is part of any match
        /// </summary>
        public bool IsTileInMatch(int x, int y)
        {
            List<Tile> horizontalMatch = CheckHorizontalMatch(x, y);
            List<Tile> verticalMatch = CheckVerticalMatch(x, y);

            return horizontalMatch.Count >= minMatchLength || verticalMatch.Count >= minMatchLength;
        }
    }
}
