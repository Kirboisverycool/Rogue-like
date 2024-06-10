using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    public static ScreenShake instance;

    public bool canShake = true;
    public float globalShakeForce = 1f;
    public float shakeDelay = 0.5f;

    [SerializeField] private CinemachineImpulseListener impulseListener;

    private CinemachineImpulseDefinition impulseDefinition; 

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }

    public void ScreenShakeFromProfile(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        SetupScreenShakeSettings(profile, impulseSource);

        impulseSource.GenerateImpulseWithForce(profile.impulseForce);

        //StartCoroutine(CanShakeScreen(profile, impulseSource));
    }

    private IEnumerator CanShakeScreen(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        canShake = true;
        impulseSource.GenerateImpulseWithForce(profile.impulseForce);
        yield return new WaitForSeconds(shakeDelay);
        canShake = false;
    }

    private void SetupScreenShakeSettings(ScreenShakeProfile profile, CinemachineImpulseSource impulseSource)
    {
        impulseDefinition = impulseSource.m_ImpulseDefinition;

        impulseDefinition.m_ImpulseDuration = profile.impulseTime;
        impulseSource.m_DefaultVelocity = profile.defaultVelocity;
        impulseDefinition.m_CustomImpulseShape = profile.impulseCurve;

        impulseListener.m_ReactionSettings.m_AmplitudeGain = profile.listenerAmplitude;
        impulseListener.m_ReactionSettings.m_FrequencyGain = profile.listenerFrequency;
        impulseListener.m_ReactionSettings.m_Duration = profile.listenerDuration;
    }
}
