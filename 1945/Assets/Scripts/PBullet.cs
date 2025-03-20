using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float bulletSpeed = 4.0f;
    public int bulletDamage = 0;
    public GameObject effect;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {

            GameObject ef = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(ef, 1);

            // Destroy(collision.gameObject);
            collision.GetComponent<Enemy>().Hit(bulletDamage);


            Destroy(gameObject);

        }
        
        if (collision.CompareTag("Boss"))
        {

            GameObject ef = Instantiate(effect, collision.transform.position, Quaternion.identity);
            Destroy(ef, 1);

            // Destroy(collision.gameObject);

            Destroy(gameObject);

        }
    }
}
