using UnityEngine;

public class MonoBehaviorExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start: ���۵ɶ� �ѹ� ȣ��");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: �� �����Ӹ��� ȣ��");
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed Update: ���� �ð����� ȣ�� - ���� ���꿡 ���");
    }
}
