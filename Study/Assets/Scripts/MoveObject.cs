using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f; // 이동속도

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
        // transform.Translate(move * speed * Time.deltaTime);

        transform.position += (move * speed * Time.deltaTime);


    }
}
