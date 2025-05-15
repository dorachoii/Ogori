using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameState CurrentState;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public enum Player
    {
        Player1,
        Player2,
        Unknown
    }

    public enum MiniGameType
    {
        BubbleGame
    }

    public enum GameState
    {
        Pause,
        Running,
        End
    }

    // GameManager.cs
    public void EndGame(Player winner)
    {
        if (CurrentState == GameState.End) return;

        CurrentState = GameState.End;

        Debug.Log($"게임 종료! 승자는: {winner}");
    }

}
