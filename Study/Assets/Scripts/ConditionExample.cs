using UnityEngine;

public class ConditionExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int hp = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp -= 1; //ü�� ����
        Debug.Log("Health: " + hp);

        //���ǹ�
        if (hp <= 0)
        {
            Debug.Log("Game Over!");
        }
    }
}
