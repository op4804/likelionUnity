using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f; // 이동속도

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);


    }
}
