using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Slash : MonoBehaviour
{

    private GameObject p;
    Vector3 direction;

    float angle;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player");

        Transform tr = p.GetComponent<Transform>();
        Vector2 mouse = Input.mousePosition;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        Vector3 pos = new Vector3(mouse.x, mouse.y, 0);
        direction = pos - tr.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }

    // Update is called once per frame
    void Update()
    {
        // 회전 적용
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = p.transform.position;
    }

    public void Des()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌한 물체가 적 미사일인지 확인
        if (collision.gameObject.GetComponent<EnemyBullet>() != null)
        {
            //미사일의 현재 방향 가져오기
            EnemyBullet missile = collision.gameObject.GetComponent<EnemyBullet>();
            SpriteRenderer missileSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            //현재 방향의 정반대 방향으로 설정(-1을 곱하면 반대 방향이 됨)
            Vector2 reverseDir = -missile.GetDirection();

            //미사일의 새로운 방향 설정
            missile.SetDirection(reverseDir);


            //스프라이트 방향 뒤집기
            if (missileSprite != null)
            {
                missileSprite.flipX = !missileSprite.flipX;
            }

            

        }
        if (collision.CompareTag("Enemy"))
        {
            //적의 죽음 애니메이션 실행
            Wizard enemy = collision.GetComponent<Wizard>();
            if (enemy != null)
            {
                enemy.PlayDeathAnimation();
            }
        }
    }
}
