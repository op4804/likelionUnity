using UnityEngine;

public class Launcher : MonoBehaviour
{


    public GameObject bullet;

    void Start()
    {
        // InvokeRepeating(�Լ��̸�, �ʱ� �����ð�, �����ð�)
        InvokeRepeating("Shoot", 0.5f, 0.5f);
    }

    void Shoot()
    {
        // �̻��� ������, ��ó ������, ���Ⱚ

        Instantiate(bullet, transform.position, Quaternion.identity);
        // SoundManager.instacne.PlayBulletSound();
    }

}
