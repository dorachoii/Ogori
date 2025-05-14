using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    public  GameState CurrentState;

    void Awake()
    {
        if(Instance == null) Instance = this;
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
        None 
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

    public void EndGame(Player winner)
    {

    CurrentState = GameState.End;

    if (winner == Player.None)
    {
        // 시간이 다 되었을 때 판정 위임

            BubbleJudge.Instance.CheckBarPos();
    }

    Debug.Log($"게임 종료! 승자는: {winner}");
    }
}
