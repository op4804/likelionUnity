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
            Instantiate(missile, launcherL.position, Quaternion.identity); // ����
            Instantiate(missile, launcherR.position, Quaternion.identity); // ������
            yield return new WaitForSeconds(0.5f);
        }
    }

    // �� �������� �̻��� �߻�
    IEnumerator BossAttack()
    {
        // �����ֱ�
        float attackRate = 5f;
        // �߻�ü ��������
        int count = 20;
        // �߻�ü ������ ����
        float intervalAngle = 360 / count;
        // ���ߵǴ� ���� (�׻� ���� ��ġ�� �߻����� �ʵ��� ����)
        float weightAngle = 0f;

        while (true)
        {
            for(int i = 0; i < count; i++)
            {
                GameObject bb = Instantiate(bossBullet, transform.position, Quaternion.identity);

                // �߻�ü �̵� ���� (����)
                float angle = weightAngle + intervalAngle * i;
                // �߻�ü �̵� ���� (����)

                //Cos(����)���� ������ ���� ǥ���� ���� pi/180�� ����
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(����)���� ������ ���� ǥ���� ���� pi/180�� ����
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

        // ���� �¿�� �̵�

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
