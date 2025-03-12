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
        Debug.Log("코루틴 시작");
        yield return new WaitForSeconds(2f);
        Debug.Log("2초 후 실행");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
