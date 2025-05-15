using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float duration = 10f; 
    private float currentTime;

    void Start()
    {
        ResetTimer();
    }

    void Update()
    {
        if ( GameManager.Instance.CurrentState != GameManager.GameState.Running) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            BubbleJudge.Instance.CheckBarPos();
        }

        text.text = Mathf.CeilToInt(currentTime).ToString(); 
    }

    public void ResetTimer()
    {
        currentTime = duration;
        GameManager.Instance.CurrentState = GameManager.GameState.Running;
    }

    public void PauseTimer()
    {
        GameManager.Instance.CurrentState = GameManager.GameState.Pause;
    }
}
