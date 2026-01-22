using UnityEngine;
using UnityEngine.SceneManagement;

namespace PuzzleGame.GameManagement
{
    /// <summary>
    /// Core game manager handling FSM state transitions and game loop
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [Header("Game State")]
        [SerializeField] private GameState currentState = GameState.Menu;

        [Header("References")]
        [SerializeField] private ScoreManager scoreManager;
        [SerializeField] private GridManager gridManager;

        private void Awake()
        {
            // Singleton pattern
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            ChangeState(GameState.Menu);
        }

        /// <summary>
        /// Changes the current game state
        /// </summary>
        public void ChangeState(GameState newState)
        {
            // Exit current state
            ExitState(currentState);

            // Update state
            currentState = newState;

            // Enter new state
            EnterState(newState);
        }

        private void EnterState(GameState state)
        {
            switch (state)
            {
                case GameState.Menu:
                    Time.timeScale = 1f;
                    // Load menu scene or show menu UI
                    break;

                case GameState.Gameplay:
                    Time.timeScale = 1f;
                    if (gridManager != null)
                    {
                        gridManager.InitializeGrid();
                    }
                    break;

                case GameState.Paused:
                    Time.timeScale = 0f;
                    break;

                case GameState.GameOver:
                    Time.timeScale = 0f;
                    // Show game over UI
                    break;
            }

            Debug.Log($"Entered State: {state}");
        }

        private void ExitState(GameState state)
        {
            switch (state)
            {
                case GameState.Menu:
                    // Cleanup menu
                    break;

                case GameState.Gameplay:
                    // Save score, cleanup gameplay
                    break;

                case GameState.Paused:
                    // Resume time handled in new state
                    break;

                case GameState.GameOver:
                    // Cleanup game over UI
                    break;
            }
        }

        public void StartGame()
        {
            ChangeState(GameState.Gameplay);
        }

        public void PauseGame()
        {
            if (currentState == GameState.Gameplay)
            {
                ChangeState(GameState.Paused);
            }
        }

        public void ResumeGame()
        {
            if (currentState == GameState.Paused)
            {
                ChangeState(GameState.Gameplay);
            }
        }

        public void EndGame()
        {
            ChangeState(GameState.GameOver);
        }

        public void ReturnToMenu()
        {
            ChangeState(GameState.Menu);
        }

        public GameState GetCurrentState()
        {
            return currentState;
        }
    }
}
