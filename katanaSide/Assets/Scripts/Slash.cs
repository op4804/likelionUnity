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
        // ȸ�� ����
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.position = p.transform.position;
    }

    public void Des()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�浹�� ��ü�� �� �̻������� Ȯ��
        if (collision.gameObject.GetComponent<EnemyBullet>() != null)
        {
            //�̻����� ���� ���� ��������
            EnemyBullet missile = collision.gameObject.GetComponent<EnemyBullet>();
            SpriteRenderer missileSprite = collision.gameObject.GetComponent<SpriteRenderer>();

            //���� ������ ���ݴ� �������� ����(-1�� ���ϸ� �ݴ� ������ ��)
            Vector2 reverseDir = -missile.GetDirection();

            //�̻����� ���ο� ���� ����
            missile.SetDirection(reverseDir);


            //��������Ʈ ���� ������
            if (missileSprite != null)
            {
                missileSprite.flipX = !missileSprite.flipX;
            }

            

        }
        if (collision.CompareTag("Enemy"))
        {
            //���� ���� �ִϸ��̼� ����
            Wizard enemy = collision.GetComponent<Wizard>();
            if (enemy != null)
            {
                enemy.PlayDeathAnimation();
            }
        }
    }
}
