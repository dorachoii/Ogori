using System.Threading;
using UnityEngine;

public class BubbleJudge : MonoBehaviour
{
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

        if (barScreenPos.x <= 0 || barScreenPos.x >= Screen.width)
        {
            var winner = (barScreenPos.x <= 0)
                ? GameManager.Player.Player1
                : GameManager.Player.Player2;

            GameManager.Instance.EndGame(winner);
        }
    }

    public void CheckBarPos()
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        print($"{barScreenPos.x} screen: {Screen.width / 2} currentState {GameManager.Instance.CurrentState}");

        GameManager.Player winner = (barScreenPos.x > Screen.width / 2)
            ? GameManager.Player.Player2
            : GameManager.Player.Player1;

        GameManager.Instance.EndGame(winner);
    }
}
