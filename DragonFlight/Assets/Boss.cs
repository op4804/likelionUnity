using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject dragonSummon;
    int moveDir = 1;
    void Start()
    {
        StartCoroutine(BossMoving());
        StartCoroutine(BossPattern());
    }

    private void Update()
    {
        transform.Translate(1 * Time.deltaTime * moveDir, 0, 0);
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
        Instantiate(dragonSummon);
        yield return new WaitForSeconds(2f);
    }
}
