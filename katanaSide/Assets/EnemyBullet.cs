using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public float speed = 5f;    //�̻��� �ӵ�
    public float lifeTime = 3f; //�̻��� ���� �ð�
    public int damage = 10;     //�̻��� ������
    public Vector2 direction = Vector2.left;  //�̻��� �̵� ����


    void Start()
    {
        Destroy(gameObject, lifeTime);  //���� �ð� �� �̻��� ����     
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
    }


    void Update()
    {
        float timeScale = TimeController.instance.GetTimeScale();
        transform.Translate(direction * speed * timeScale * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //���⿡ �÷��̾� ������ ���� �߰�
            Destroy(gameObject);
        }

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Wizard>().PlayDeathAnimation();
            Destroy(gameObject);
        }
    }

    public Vector2 GetDirection()
    {
        return direction;
    }
}
