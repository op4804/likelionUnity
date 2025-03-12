using UnityEngine;

public class GameCube : MonoBehaviour
{

    float speed = 0.4f;

    float ox;
    float oy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ox = this.transform.position.x;
        oy = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed;

        if(transform.position.z < -10)
        {
            transform.position = new Vector3(ox, oy, 50);
        }
        
    }
}
