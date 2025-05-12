using UnityEngine;
using UnityEngine.InputSystem;

public class CircleSpawner : MonoBehaviour
{
    public GameObject circle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 screenPos = Input.mousePosition;
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(new Vector2(screenPos.x, screenPos.y));
            
            float radius = circle.transform.localScale.x;

            Collider2D[] hits = Physics2D.OverlapCircleAll(worldPos, radius);

            if(hits.Length == 0){
                Instantiate(circle, worldPos, Quaternion.identity);
            }else{
                Vector2 totalOffset = Vector2.zero;
                foreach (var hit in hits)
                {
                    Vector2 dir = (worldPos - (Vector2)hit.transform.position).normalized;
                    float minDistance = radius * 2f;
                    totalOffset += dir * minDistance;
                }
                Vector2 newPos = worldPos + totalOffset / hits.Length;
            }
        }
    }
}


