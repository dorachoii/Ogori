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

    public void CheckBarPos()
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        if(barScreenPos.y > ScreenHeight/2){
            Debug.Log("Down Player win!");
        }else
        {
            Debug.Log("Up Player win!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
