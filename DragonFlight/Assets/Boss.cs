using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject dragonSummon;
    int moveDir = 1;

    public GameObject explosion;
    void Start()
    {
        StartCoroutine(BossMoving());
        StartCoroutine(BossPattern());
    }

    private void Update()
    {
        transform.Translate(1 * Time.deltaTime * moveDir, 0, 0);

        if(GameManager.instance.score > 300)
        {
            Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            newPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            Instantiate(explosion, newPosition, Quaternion.identity);
            newPosition = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            Instantiate(explosion, newPosition, Quaternion.identity);
            newPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            Instantiate(explosion, newPosition, Quaternion.identity);
            Invoke("Death", 2f);
        }
    }
    IEnumerator BossMoving()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if (moveDir > 0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;
            }
        }
    }
    IEnumerator BossPattern()
    {
        while (true)
        {
            
            yield return new WaitForSeconds(1.78f);
            Instantiate(dragonSummon, transform.position, Quaternion.identity);
        }
        
    }
    void Death()
    {
        GameManager.instance.isGameClear = true;
        GameManager.instance.ActiveClearScoreText();
        Destroy(gameObject);
    }
}
