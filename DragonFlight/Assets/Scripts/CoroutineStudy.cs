using System.Collections;
using UnityEngine;

public class CoroutineStudy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }


    IEnumerator ExampleCoroutine()
    {
        Debug.Log("�ڷ�ƾ ����");
        yield return new WaitForSeconds(2f);
        Debug.Log("2�� �� ����");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
