using UnityEngine;

public class EBulletHoming : MonoBehaviour
{


    public GameObject target;
    public float bulletSpeed = 2f;

    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        // �±׷� �÷��̾� ã��
        target = GameObject.FindGameObjectWithTag("Player");
        // A - B => A�� �ٶ󺸴� ���� �÷��̾� - �̻��� => �÷��̾ �ٶ󺸴� ����
        dir = target.transform.position - transform.position;
        // ���⸸ ���ϱ� -> ����ȭ(Normalize)
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
