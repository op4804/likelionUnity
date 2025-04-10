using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeController : MonoBehaviour
{

    public static TimeController instance;

    public bool isSlowMotion = false;
    public float slowMotionDuration = 0.5f; // ���ο� ��� ���� �ð�
    private float slowMotionTimer = 0f;
    public float slowMotionTimeSclae = 0.3f; // ���ο� ��� �ð� ����


    [Header("Post Processing")]
    public PostProcessVolume postProcessVolume;
    private Vignette vignette;
    private ColorGrading colorGrading;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void Start()
    {
        // post processing �ʱ�ȭ
        postProcessVolume.profile.TryGetSettings(out vignette);
        postProcessVolume.profile.TryGetSettings(out colorGrading);
    }


    void Update()
    {
        if (isSlowMotion)
        {
            slowMotionTimer += Time.deltaTime;
            if(slowMotionTimer >= slowMotionDuration)
            {
                SetSloawMotion(false);
                slowMotionTimer = 0;
            }
        }
    }

    public float GetTimeScale()
    {
        return isSlowMotion ? slowMotionTimeSclae : 1f;
    }

    public void SetSloawMotion(bool slow)
    {
        isSlowMotion = slow;
        if (slow)
        {
            // ���ο� ��� ���۽� ȿ��
            slowMotionTimer = 0;

            vignette.intensity.value = 0.8f;         // ���Ʈ ���� ���� ����
            colorGrading = postProcessVolume.profile.GetSetting<ColorGrading>();
            colorGrading.saturation.value = -40f;    // ä�� ���� ����
            colorGrading.temperature.value = -25f;    // �ſ� ������ ����
            colorGrading.contrast.value = 20f;        // ��� �� ���ϰ�
            colorGrading.postExposure.value = -1.0f;  // ��ü������ �� ��Ӱ�
            colorGrading.tint.value = 10f;           // �ణ�� �ʷϺ� �߰�
        }
        else
        {
            // ���ο� ��� ����� ȿ�� �ʱ�ȭ
            vignette.intensity.value = 0f;
            colorGrading.saturation.value = 0f;
            colorGrading.temperature.value = 0f;
            colorGrading.contrast.value = 0f;
            colorGrading.postExposure.value = 0f;
            colorGrading.tint.value = 0f;
        }
    }
}
