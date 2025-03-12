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
        // �̻��ϰ� ���� �ε������� (tag�� �̿��� ��)
        if(collision.gameObject.tag == "Enemy")
        {

            // ���� ����Ʈ ����
            Instantiate(explosion, collision.transform.position, Quaternion.identity);
            // �� �����

            Destroy(collision.gameObject);
            // �� ���� ����
            SoundManager.instacne.PlayEnemyDie();
            // ���� �߰�
            GameManager.instance.AddScore(10);

            // �̻��� �����
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag == "Boss")
        {
            // ���� ����Ʈ ����
            Instantiate(explosion, transform.position, Quaternion.identity);
            SoundManager.instacne.PlayEnemyDie();
            // ���� �߰�
            GameManager.instance.AddScore(1);

            // �̻��� �����
            Destroy(gameObject);
        }
    }
}
