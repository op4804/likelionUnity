using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 1.8f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceY = moveSpeed * Time.deltaTime;

        transform.Translate(0, -DistanceY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); // °´Ã¼ Á¦°Å
    }
}
