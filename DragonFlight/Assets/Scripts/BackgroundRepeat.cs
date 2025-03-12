using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    // �����̴� �ӵ�
    public float scrollSpeed = 0.4f;

    // ���׸��� �����͸� ������ ��ü
    private Material mt;


    private void Start()
    {
        // ���� Renderer������Ʈ�� Material������ �޾ƿ���
        mt = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        // ���� y���� �ӵ� �����ֱ�.
        // mt.mainTextureOffset.y += (scrollSpeed * Time.deltaTime); ������ �ƴ϶� �� �Ҵ� �Ұ���.

        // ���Ӱ� �������� offset��ü ����
        Vector2 newOffset = mt.mainTextureOffset;
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));
        mt.mainTextureOffset = newOffset;
    }
}
