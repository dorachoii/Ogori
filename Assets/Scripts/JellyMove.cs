using UnityEngine;

public class JellyMove : MonoBehaviour
{
    public GameObject[] cubes;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)){
            cubes[0].GetComponent<Rigidbody>().AddForce(Vector3.right*3, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.K)){
             cubes[1].GetComponent<Rigidbody>().AddForce(Vector3.left*3, ForceMode.Impulse);
        }
    }
}
