using UnityEngine;

public class EBullet : MonoBehaviour
{
    public float bulletSpeed = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * bulletSpeed * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
    // 화면에서 사라졌을 경우 파괴.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
