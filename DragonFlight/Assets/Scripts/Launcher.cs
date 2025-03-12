using UnityEngine;

public class Launcher : MonoBehaviour
{


    public GameObject bullet;

    void Start()
    {
        // InvokeRepeating(함수이름, 초기 지연시간, 지연시간)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        // 미사일 프리팹, 런처 포지션, 방향값

        Instantiate(bullet, transform.position, Quaternion.identity);
        // SoundManager.instacne.PlayBulletSound();
    }

}
