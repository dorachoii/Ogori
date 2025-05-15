using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.InputSystem;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circle;
    public GameObject bar;

    float radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        radius = circle.transform.localScale.x / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //FIX : touch로 바꾸기
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

                    // FIX: 벡터의 덧셈
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
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        return touchInputPos.x >= barScreenPos.x;
    }

    bool IsSafeScreen(Vector2 touchPos)
    {
        Vector2 barScreenPos = Camera.main.WorldToScreenPoint(bar.transform.position);
        float center = barScreenPos.x;
        float margin = 20f;

        return touchPos.x >= center + margin || touchPos.x <= center - margin;
    }

    void SpawnCircle(Vector2 pos, Vector2 touchPos)
    {
        GameObject newCircle = Instantiate(circle, pos, Quaternion.identity);
        Rigidbody2D[] rbs = newCircle.GetComponentsInChildren<Rigidbody2D>();
        foreach (var rb in rbs)
        {
            rb.gravityScale = isUpperScreen(touchPos) ? 0.2f : -0.2f;
        }
    }
}

