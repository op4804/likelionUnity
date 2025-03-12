using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public Rigidbody rb;

    public float jumpForce = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
