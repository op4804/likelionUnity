using UnityEngine;

public class MonoBehaviorExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start: 시작될때 한번 호출");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update: 매 프레임마다 호출");
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed Update: 고정 시간마다 호출 - 물리 연산에 사용");
    }
}
