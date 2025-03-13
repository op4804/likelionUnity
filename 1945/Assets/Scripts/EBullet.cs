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
    
    // ȭ�鿡�� ������� ��� �ı�.
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
