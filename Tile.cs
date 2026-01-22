using UnityEngine;

namespace PuzzleGame.Grid
{
    /// <summary>
    /// Individual tile logic including type, position, and visual representation
    /// </summary>
    public class Tile : MonoBehaviour
    {
        [Header("Tile Data")]
        [SerializeField] private int tileType;
        [SerializeField] private int gridX;
        [SerializeField] private int gridY;

        [Header("Visual")]
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color[] tileColors;

        private bool isSelected = false;

        /// <summary>
        /// Initializes tile with grid position and type
        /// </summary>
        public void Initialize(int x, int y, int type)
        {
            gridX = x;
            gridY = y;
            tileType = type;

            UpdateVisual();
        }

        /// <summary>
        /// Updates tile visual based on type
        /// </summary>
        private void UpdateVisual()
        {
            if (spriteRenderer != null && tileColors != null && tileType < tileColors.Length)
            {
                spriteRenderer.color = tileColors[tileType];
            }
        }

        /// <summary>
        /// Sets new grid position (used when swapping)
        /// </summary>
        public void SetGridPosition(int x, int y)
        {
            gridX = x;
            gridY = y;

            // TODO: Add smooth movement animation
            transform.position = new Vector3(x, y, 0);
        }

        /// <summary>
        /// Handles tile selection/deselection
        /// </summary>
        public void SetSelected(bool selected)
        {
            isSelected = selected;
            // TODO: Add visual feedback for selection (outline, scale, etc.)
        }

        /// <summary>
        /// Destroys this tile (for matches)
        /// </summary>
        public void DestroyTile()
        {
            // TODO: Add particle effect or animation
            Destroy(gameObject);
        }

        // Getters
        public int TileType => tileType;
        public int GridX => gridX;
        public int GridY => gridY;
        public bool IsSelected => isSelected;

        private void OnMouseDown()
        {
            // TODO: Handle player input for tile selection
            Debug.Log($"Tile clicked at ({gridX}, {gridY}) - Type: {tileType}");
        }
    }
}
