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
        dir = pos - tr.position; // 마우스 좌표 - 플레이어 좌표 -> 플레이어에서 마우스로 가는 벡터


        dirNo = new Vector3(dir.x, dir.y, 0).normalized;


        // 각도 구하기
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Destroy(gameObject, 4f);
    }


    void Update()
    {
        // 방향
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // 이동        
        transform.position += dirNo * Speed * Time.deltaTime;
    }
}