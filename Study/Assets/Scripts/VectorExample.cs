using UnityEngine;

public class VectorExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 a = new Vector3(1, 1, 0);
        Vector3 b = new Vector3(2, 0, 0);
        Vector3 c = a + b;

        

        Debug.Log("Vector c " + c);
        Debug.Log("Vector length " + c.magnitude);
        Debug.Log("Vector normalize " + c.normalized);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
