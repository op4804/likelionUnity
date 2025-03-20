using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{


    public static CameraShake instance;
    // Impulse Source 컴포넌트

    private CinemachineImpulseSource impulseSource;


    void Awake()
    {
        instance = this;

        impulseSource = GetComponent<CinemachineImpulseSource>();

    }


    public void ShowCameraShake()
    {
        if (impulseSource != null)
        {
            //기본 설정으로 임펄스 생성
            impulseSource.GenerateImpulse();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetImpulseSource(CinemachineImpulseSource cinemachineImpulseSource)
    {
        impulseSource = cinemachineImpulseSource;
    }
}
