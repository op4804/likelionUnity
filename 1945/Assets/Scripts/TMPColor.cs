using System.Collections;
using TMPro;
using UnityEngine;

public class TMPColor : MonoBehaviour
{



    [SerializeField]
    float lerpTime = 0.1f;

    TextMeshProUGUI textBossWarning;

    private void Awake()
    {
        textBossWarning = GetComponent<TextMeshProUGUI>();

    }

    // ������Ʈ�� Ȱ��ȭ �ɶ�
    private void OnEnable()
    {
        StartCoroutine(ColorLerpLoop());
    }

    IEnumerator ColorLerpLoop()
    {
        while(true)
        {
            yield return StartCoroutine(ColorLerp(Color.white, Color.red));
            yield return StartCoroutine(ColorLerp(Color.red, Color.white));
        }
    }

    IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while(percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / lerpTime;
            textBossWarning.color = Color.Lerp(startColor, endColor, percent);
            yield return null;
        }
    }
}
