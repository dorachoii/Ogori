using UnityEngine;

public class BingoJudge : MonoBehaviour
{
    bool is1P;
    public GameObject[] stones;

    int[,] board = new int[3, 3];



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero);

            if (hit.collider != null && hit.collider.name.Contains("Stone"))
            {
                PutStone(hit.collider.transform.position);
            }
        }
    }


    (int, int) FindCoordinate(int idx)
    {
        return (idx / 3, idx % 3);
    }


    void PutStone(Vector2 pos)
    {
        GameObject stone = is1P ? stones[0] : stones[1];
        is1P = !is1P;

        Instantiate(stone, pos, Quaternion.identity);
    }
}
