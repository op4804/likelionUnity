using Unity.VisualScripting;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    private static BulletFactory instance;

    public static BulletFactory Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject singletonObject = new GameObject("BulletFactory");
                instance = singletonObject.AddComponent<BulletFactory>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else // �ν��Ͻ��� null�� �ƴҰ�� -> ��, �̹� �ν��Ͻ��� ������ ���
        {
            Destroy(gameObject);
        }
    }

    public GameObject bullet;

    public GameObject FIreBullet(Vector3 position)
    {
        GameObject newBullet = Instantiate(bullet, position, Quaternion.identity);
        return newBullet;
    }
}
