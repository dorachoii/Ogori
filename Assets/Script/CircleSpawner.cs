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
        radius = circle.transform.localScale.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchInputPos = Input.mousePosition;
            Vector2 touchWorldPos = Camera.main.ScreenToWorldPoint(new Vector2(touchInputPos.x, touchInputPos.y));

            if (IsSafeScreen(touchInputPos))
            {
                Collider2D[] hits = Physics2D.OverlapCircleAll(touchWorldPos, radius);

                if (hits.Length == 0)
                {
                    SpawnCircle(touchWorldPos, touchInputPos);
                }
                else
                {
                    Vector2 offset = Vector2.zero;

                    foreach (var hit in hits)
                    {
                        Vector2 dir = (touchWorldPos - (Vector2)hit.transform.position).normalized;
                        offset += dir * radius;
                    }

                    Vector2 newPos = touchWorldPos + offset;

                    Collider2D[] recheck = Physics2D.OverlapCircleAll(newPos, radius);
                    if (recheck.Length == 0)
                    {
                        SpawnCircle(newPos, touchInputPos);
                    }
                }
            }
        }
    }

    bool isUpperScreen(Vector2 touchInputPos)
    {
        return touchInputPos.y >= screenHeight / 2;
    }

    bool IsSafeScreen(Vector2 touchPos)
    {
        float center = screenHeight / 2f;
        float margin = 20f;

        return touchPos.y >= center + margin || touchPos.y <= center - margin;
    }

    void SpawnCircle(Vector2 pos, Vector2 touchPos)
    {
        GameObject newCircle = Instantiate(circle, pos, Quaternion.identity);
        Rigidbody2D[] rbs = newCircle.GetComponentsInChildren<Rigidbody2D>();
        foreach (var rb in rbs)
        {
            rb.gravityScale = isUpperScreen(touchPos) ? 1f : -1f;
        }
    }
}

