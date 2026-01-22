using System.Collections.Generic;
using UnityEngine;

namespace PuzzleGame.Grid
{
    public class MatchDetector : MonoBehaviour
    {
        [SerializeField] private GridManager gridManager;
        [SerializeField] private int minMatchLength = 3;

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

        public bool IsTileInMatch(int x, int y)
        {
            List<Tile> horizontalMatch = CheckHorizontalMatch(x, y);
            List<Tile> verticalMatch = CheckVerticalMatch(x, y);

            return horizontalMatch.Count >= minMatchLength || verticalMatch.Count >= minMatchLength;
        }
    }
}
