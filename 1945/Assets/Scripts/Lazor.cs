using System.Threading;
using UnityEngine;

public class Lazor : MonoBehaviour
{
    int lazorDamage = 10;

    Transform pos;

    public GameObject effect;
    void Start()
    {
        pos = GameObject.Find("Player").GetComponent<Player>().pos;
    }

    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit(lazorDamage);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit(lazorDamage);

            CreateEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            CreateEffect(collision.transform.position);
        }
    }

    void CreateEffect(Vector3 position)
    {
        GameObject go = Instantiate(effect, position, Quaternion.identity);
        Destroy(go, 1);
    }
}
