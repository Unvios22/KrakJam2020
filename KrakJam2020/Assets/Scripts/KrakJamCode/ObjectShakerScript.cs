using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class ObjectShakerScript : MonoBehaviour{
    public float ShakeDuration = 0.3f;
    public float ShakeAmplitude = 1.2f;
    public float ShakeFrequency = 2.0f;

    float ShakeElapsedTime = 0f;

    public CinemachineVirtualCamera VirtualCamera;
    CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    void Start(){
        if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void Shake(){
        StartCoroutine(StartShake());
    }

    IEnumerator StartShake(){
        ShakeElapsedTime = ShakeDuration;
        virtualCameraNoise.m_AmplitudeGain = ShakeAmplitude;
        virtualCameraNoise.m_FrequencyGain = ShakeFrequency;
        while (ShakeElapsedTime > 0){
            ShakeElapsedTime -= Time.deltaTime;
            yield return null;
        }
        virtualCameraNoise.m_AmplitudeGain = 0f;
        ShakeElapsedTime = 0f;
    }
}
