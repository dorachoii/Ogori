using System.Threading;
using UnityEngine;

public class BubbleJudge : MonoBehaviour
{
    int ScreenHeight;
    public static BubbleJudge Instance{ get; private set;}
    GameObject bar;

    void Awake()
    {
        if(Instance == null)
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
        if(GameManager.Instance.CurrentState == GameManager.GameState.Running){
            CheckEndByBar();
        }
    }

    void CheckEndByBar()
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        
        if (barScreenPos.y <= 0)
        {
            GameManager.Instance.EndGame(GameManager.Player.Player1);

        }
        else if (barScreenPos.y >= Screen.height)
        {
            GameManager.Instance.EndGame(GameManager.Player.Player2);
        }
    }

    public void CheckBarPos()
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        if(barScreenPos.y > ScreenHeight/2){
             GameManager.Instance.EndGame(GameManager.Player.Player2);
        }else
        {
            GameManager.Instance.EndGame(GameManager.Player.Player1);
        }
    }

}
