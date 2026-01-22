using UnityEngine;

namespace PuzzleGame.GameManagement
{
    /// <summary>
    /// Manages score, combo system, and high score persistence
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        [Header("Score Settings")]
        [SerializeField] private int basePointsPerTile = 10;
        [SerializeField] private float comboMultiplier = 1.5f;

        private int currentScore = 0;
        private int currentCombo = 0;
        private int highScore = 0;

        private const string HIGH_SCORE_KEY = "HighScore";

        private void Start()
        {
            LoadHighScore();
        }

        /// <summary>
        /// Adds points based on tiles matched and current combo
        /// </summary>
        public void AddScore(int tilesMatched)
        {
            int points = Mathf.RoundToInt(basePointsPerTile * tilesMatched * Mathf.Pow(comboMultiplier, currentCombo));
            currentScore += points;

            Debug.Log($"Score Added: {points} | Total: {currentScore} | Combo: {currentCombo}");

            // Check for high score
            if (currentScore > highScore)
            {
                highScore = currentScore;
                SaveHighScore();
            }
        }

        /// <summary>
        /// Increments combo counter for chain reactions
        /// </summary>
        public void IncrementCombo()
        {
            currentCombo++;
        }

        /// <summary>
        /// Resets combo when no more matches occur
        /// </summary>
        public void ResetCombo()
        {
            currentCombo = 0;
        }

        /// <summary>
        /// Resets current score for new game
        /// </summary>
        public void ResetScore()
        {
            currentScore = 0;
            currentCombo = 0;
        }

        public int GetCurrentScore() => currentScore;
        public int GetCurrentCombo() => currentCombo;
        public int GetHighScore() => highScore;

        private void SaveHighScore()
        {
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, highScore);
            PlayerPrefs.Save();
        }

        private void LoadHighScore()
        {
            highScore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        }
    }
}
