using UnityEngine;

public class HitLazer : MonoBehaviour
{
    float Speed = 50f;
    Vector2 mousePos;
    Vector2 mousePosToWorld;
    Transform tr;
    Vector3 dir;

    float angle;
    Vector3 dirNo;


    void Start()
    {
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        mousePos = Input.mousePosition;
        mousePosToWorld = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 pos = new Vector3(mousePosToWorld.x, mousePosToWorld.y, 0);
        dir = pos - tr.position; // ���콺 ��ǥ - �÷��̾� ��ǥ -> �÷��̾�� ���콺�� ���� ����


        dirNo = new Vector3(dir.x, dir.y, 0).normalized;


        // ���� ���ϱ�
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Destroy(gameObject, 4f);
    }


    void Update()
    {
        // ����
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // �̵�        
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}