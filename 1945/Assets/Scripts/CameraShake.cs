using System;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{


    public static CameraShake instance;
    // Impulse Source ������Ʈ

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
            //�⺻ �������� ���޽� ����
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
