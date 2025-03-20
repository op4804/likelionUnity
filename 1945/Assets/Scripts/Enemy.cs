using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 2f;
    public float delay = 1f;
    public Transform launcherL;
    public Transform launcherR;
    public GameObject enemyBullet;

    public GameObject item;

    public float hp = 100;
    
    void Start()
    {
        StartCoroutine(FireBullet());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);   

        if(hp < 0)
        {
            EnemyDestroy();
        }
    }

    IEnumerator FireBullet()
    {
        while(true)
        {
            yield return new WaitForSeconds(delay);
            Instantiate(enemyBullet, launcherL.position, Quaternion.identity);
            Instantiate(enemyBullet, launcherR.position, Quaternion.identity);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void EnemyDestroy()
    {
        if (Random.Range(0,3) == 0)
        {
            Instantiate(item, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

    public void Hit(int damage)
    {
        hp -= damage;
    }
}
