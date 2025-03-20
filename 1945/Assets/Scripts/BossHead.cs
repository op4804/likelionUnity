using UnityEngine;

public class BossHead : MonoBehaviour
{
    [SerializeField]
    GameObject bossBullet;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().SetDir(new Vector2(1, -1));
    }



    public void LeftDownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().SetDir(new Vector2(-1, -1));

    }

    public void DownLaunch()
    {
        GameObject go = Instantiate(bossBullet, transform.position, Quaternion.identity);

        go.GetComponent<BossBullet>().SetDir(new Vector2(0, -1));

    }
}
