using UnityEngine;

namespace PuzzleGame.Grid
{
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

        private void UpdateVisual()
        {
            if (spriteRenderer != null && tileColors != null && tileType < tileColors.Length)
            {
                spriteRenderer.color = tileColors[tileType];
            }
        }

        public void SetGridPosition(int x, int y)
        {
            gridX = x;
            gridY = y;

            // TODO: Add smooth movement animation
            transform.position = new Vector3(x, y, 0);
        }

        public void SetSelected(bool selected)
        {
            isSelected = selected;
        }

        public void DestroyTile()
        {

            Destroy(gameObject);
        }


        public int TileType => tileType;
        public int GridX => gridX;
        public int GridY => gridY;
        public bool IsSelected => isSelected;

        private void OnMouseDown()
        {
            Debug.Log($"Tile clicked at ({gridX}, {gridY}) - Type: {tileType}");
        }
    }
}
