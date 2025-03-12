using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    // 움직이는 속도
    public float scrollSpeed = 0.4f;

    // 마테리얼 데이터를 가져올 객체
    private Material mt;


    private void Start()
    {
        // 현재 Renderer컴포넌트의 Material정보를 받아오기
        mt = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // 현재 y값에 속도 더해주기.
        // mt.mainTextureOffset.y += (scrollSpeed * Time.deltaTime); 변수가 아니라 값 할당 불가능.

        // 새롭게 지정해줄 offset객체 선언
        Vector2 newOffset = mt.mainTextureOffset;
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));
        mt.mainTextureOffset = newOffset;
    }
}
