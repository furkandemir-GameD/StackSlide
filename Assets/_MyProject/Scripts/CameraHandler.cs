using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private float ShakeElapsedTime = 0f;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;
    private void Awake() => Init(); 

    public void CameraShake()
    {
        ShakeElapsedTime = gameSettings.shakeDuration;
    }
    private void Update()
    {
        if (cinemachineVirtualCamera != null && virtualCameraNoise != null)
        {

            if (ShakeElapsedTime > 0)
            {

                virtualCameraNoise.m_AmplitudeGain = gameSettings.shakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = gameSettings.shakeFrequency;


                ShakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                virtualCameraNoise.m_AmplitudeGain = 0f;
                ShakeElapsedTime = 0f;
            }
        }
    }
    private void Init()
    {
        if (cinemachineVirtualCamera != null)
            virtualCameraNoise = cinemachineVirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        virtualCameraNoise.m_AmplitudeGain = 0f;
        ShakeElapsedTime = 0f;
    }
}
