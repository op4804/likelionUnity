using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float bulletSpeed = 2f;

    Vector2 dir = Vector2.down;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * bulletSpeed * Time.deltaTime);
    }


    public void SetDir(Vector2 vec2)
    {
        dir = vec2;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            {

        }
    }
}
