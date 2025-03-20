using System.Collections;
using System.Reflection;
using Unity.Cinemachine;
using UnityEngine;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class Boss : MonoBehaviour
{


    public GameObject missile;
    public GameObject bossBullet;


    public Transform launcherL;
    public Transform launcherR;


    private int leftRight = -1;
    private int patrolSpeed = 2;


    
    void Start()
    {
     
        StartCoroutine(BossMissile());
        StartCoroutine(BossAttack());

        CameraShake.instance.SetImpulseSource(gameObject.GetComponent<CinemachineImpulseSource>());
        CameraShake.instance.ShowCameraShake();
    }
    
    IEnumerator BossMissile()
    {
        while(true)
        {
            Instantiate(missile, launcherL.position, Quaternion.identity); // 왼쪽
            Instantiate(missile, launcherR.position, Quaternion.identity); // 오른쪽
            yield return new WaitForSeconds(0.5f);
        }
    }

    // 원 방향으로 미사일 발사
    IEnumerator BossAttack()
    {
        // 공격주기
        float attackRate = 5f;
        // 발사체 생성갯수
        int count = 20;
        // 발사체 사이의 각도
        float intervalAngle = 360 / count;
        // 가중되는 각도 (항상 같은 위치로 발사하지 않도록 설정)
        float weightAngle = 0f;

        while (true)
        {
            for(int i = 0; i < count; i++)
            {
                GameObject bb = Instantiate(bossBullet, transform.position, Quaternion.identity);

                // 발사체 이동 방향 (각도)
                float angle = weightAngle + intervalAngle * i;
                // 발사체 이동 방향 (벡터)

                //Cos(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                bb.GetComponent<BossBullet>().SetDir(new Vector2(x, y));
            }
            weightAngle++;
            yield return new WaitForSeconds(attackRate);
        }
    }

    // Update is called once per frame
    void Update()
    {

        // 보스 좌우로 이동

        if (transform.position.x > 1)
        {
            leftRight *= -1;
        }            
        else if (transform.position.x < -1)
        {
            leftRight *= -1;
        }

        transform.Translate(leftRight * patrolSpeed * Time.deltaTime, 0, 0);

    }
}
