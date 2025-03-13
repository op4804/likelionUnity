using UnityEngine;

public class EBulletHoming : MonoBehaviour
{


    public GameObject target;
    public float bulletSpeed = 2f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        // 태그로 플레이어 찾기
        target = GameObject.FindGameObjectWithTag("Player");
        // A - B => A를 바라보는 벡터 플레이어 - 미사일 => 플레이어를 바라보는 벡터
        dir = target.transform.position - transform.position;
        // 방향만 구하기 -> 정규화(Normalize)
        dirNo = dir.normalized;
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dirNo * bulletSpeed * Time.deltaTime);

        // transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.delataTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
