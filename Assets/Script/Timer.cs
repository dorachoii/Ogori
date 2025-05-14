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

        if(isRunning){
            
        }
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            isRunning = false;

            Debug.Log("⏰ Time Over!");

            GameManager.Instance.EndGame(GameManager.Player.None);
        }

        text.text = Mathf.CeilToInt(currentTime).ToString(); 
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        isRunning = true;
    }
}
