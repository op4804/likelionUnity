using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public float xStartPos = -2;
    public float xEndPos = 2;

    public float spawnRate = 1;
    public float endTime = 10f;

    public GameObject enemy;
    public GameObject enemy2;
    public GameObject boss;

    bool switchSpawn = true;
    bool switchSpawn2 = true;

    public GameObject bossWarning;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
        Invoke("StopSpawn", endTime);
    }

    IEnumerator SpawnEnemy()
    {
        while(switchSpawn)
        {
            yield return new WaitForSeconds(spawnRate);

            float x = Random.Range(xStartPos, xEndPos);

            Instantiate(enemy, new Vector2(x, transform.position.y) , Quaternion.identity);
        }
    }
    
    IEnumerator SpawnEnemy2()
    {
        while(switchSpawn2)
        {
            yield return new WaitForSeconds(spawnRate);

            float x = Random.Range(xStartPos, xEndPos);

            Instantiate(enemy2, new Vector2(x, transform.position.y) , Quaternion.identity);
        }
    }

    void StopSpawn()
    {
        switchSpawn = false;
        StopCoroutine(SpawnEnemy());
        StartCoroutine(SpawnEnemy2());

        Invoke("StopSpawn2", endTime + 20);
    }
    void StopSpawn2()
    {
        switchSpawn2 = false;
        StopCoroutine("RandomSpawn2");
        CameraShake.instance.ShowCameraShake();
        // 보스전 시작
        bossWarning.SetActive(true);
        Invoke("GenerateBoss", 5);
    }

    private void GenerateBoss()
    {
        bossWarning.SetActive(false);
        Instantiate(boss, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
