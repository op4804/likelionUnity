using UnityEngine;

public class SpwanManager : MonoBehaviour
{

    public GameObject enemy;
    void Start()
    {
        InvokeRepeating("SpwanEnemy", 1, 0.5f);
    }

    void SpwanEnemy()
    {
        // ���� ��Ÿ�� x��ǥ�� ���� ����.

        if (!GameManager.instance.isGameClear)
        {
            float randomX = Random.Range(-2f, 2f);
            Instantiate(enemy, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
