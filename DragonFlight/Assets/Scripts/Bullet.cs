using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public GameObject explosion;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        transform.Translate(0, distanceY, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 미사일과 적이 부딪혔을때 (tag를 이용해 비교)
        if(collision.gameObject.tag == "Enemy")
        {

            // 폭발 이펙트 생성
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            // 적 지우기

            Destroy(collision.gameObject);
            // 적 죽음 사운드
            SoundManager.instacne.PlayEnemyDie();
            // 점수 추가
            GameManager.instance.AddScore(10);

            // 미사일 지우기
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag == "Boss")
        {
            // 폭발 이펙트 생성
            Instantiate(explosion, transform.position, Quaternion.identity);
            SoundManager.instacne.PlayEnemyDie();
            // 점수 추가
            GameManager.instance.AddScore(1);

            // 미사일 지우기
            Destroy(gameObject);
        }
    }
}
