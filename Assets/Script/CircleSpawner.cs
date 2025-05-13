using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circle;

    int screenHeight, screenWidth;
    float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenHeight = Screen.height;
        screenWidth = Screen.width;
        radius = circle.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(new Vector2(screenPos.x, screenPos.y));

            
            GameObject newCircle = Instantiate(circle, worldPos, Quaternion.identity);
            Rigidbody2D[] rbs = newCircle.GetComponentsInChildren<Rigidbody2D>();

            foreach (var rb in rbs)
            {
                rb.gravityScale = isUpperSide(screenPos) ? 1f : -1f;
            }

        }
    }

    bool isUpperSide(Vector2 touchPos)
    {
        print($"touchPos: {touchPos.y} screenHeight: {screenHeight/2}");
        return touchPos.y >= screenHeight/2 ? true : false;
    }
}

