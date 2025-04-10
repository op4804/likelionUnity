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
        else // 인스턴스가 null이 아닐경우 -> 즉, 이미 인스턴스가 존재할 경우
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
