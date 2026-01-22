using UnityEngine;

namespace PuzzleGame.GameManagement
{
    /// <summary>
    /// Defines all possible game states for the FSM
    /// </summary>
    public enum GameState
    {
        Menu,
        Gameplay,
        Paused,
        GameOver
    }
}
