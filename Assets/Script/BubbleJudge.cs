using System.Threading;
using UnityEngine;

public class BubbleJudge : MonoBehaviour
{
    int ScreenHeight;
    public static BubbleJudge Instance { get; private set; }
    GameObject bar;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScreenHeight = Screen.height;
        bar = GameObject.FindGameObjectWithTag("Bar");
    }

    void Update()
    {
        if (GameManager.Instance.CurrentState == GameManager.GameState.Running)
        {
            CheckBarOutOfBounds();
        }
    }

    void CheckBarOutOfBounds()
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);

        if (barScreenPos.y <= 0 || barScreenPos.y >= Screen.height)
        {
            var winner = (barScreenPos.y <= 0)
                ? GameManager.Player.Player1
                : GameManager.Player.Player2;

            GameManager.Instance.EndGame(winner);
        }
    }

    public void CheckBarPos()
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        GameManager.Player winner = (barScreenPos.y > Screen.height / 2)
            ? GameManager.Player.Player2
            : GameManager.Player.Player1;

        GameManager.Instance.EndGame(winner);
    }
}
