using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float startTime = 10f; 
    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        currentTime = startTime;
    }

    void Update()
    {
        if (!isRunning) return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;

            Debug.Log("⏰ Time Over!");

            BubbleJudge.Instance.CheckBarPos();
        }

        text.text = Mathf.CeilToInt(currentTime).ToString(); 
    }

    public bool IsTimeUp()
    {
        return !isRunning;
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        isRunning = true;
    }
}
