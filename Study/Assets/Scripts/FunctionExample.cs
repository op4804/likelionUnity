using UnityEngine;

public class FunctionExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // �Լ� ����
    void SayHello()
    {
        Debug.Log("Hello! Unity");
    }

    int AdDNumbers(int a, int b)
    {
        return a + b;
    }

    void Start()
    {
        SayHello(); // �Լ� ȣ��
        int total = AdDNumbers(3, 5);
        Debug.Log($"Total : {total}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
