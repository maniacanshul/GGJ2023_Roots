using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraShakeManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public void CameraShakeOnPlayerHit()
    {
        CinemachineBasicMultiChannelPerlin perlinNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        float currentValue = 0;
        DOTween.To(() => currentValue, x => currentValue = x, 0.5f, 0.15f).SetEase(Ease.Linear).OnUpdate(() =>
        {
            perlinNoise.m_AmplitudeGain = currentValue;
        });

        float currentValueNew = 0.5f;
        DOTween.To(() => currentValueNew, x => currentValueNew = x, 0, 0.15f).SetEase(Ease.Linear).OnUpdate(() =>
      {
          perlinNoise.m_AmplitudeGain = currentValueNew;
      }).SetDelay(0.15f);
    }

    public void CameraShakeOnEnemyHit()
    {
        CinemachineBasicMultiChannelPerlin perlinNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        float currentValue = 0;
        DOTween.To(() => currentValue, x => currentValue = x, 0.25f, 0.05f).SetEase(Ease.Linear).OnUpdate(() =>
        {
            perlinNoise.m_AmplitudeGain = currentValue;
        });

        float currentValueNew = 0.25f;
        DOTween.To(() => currentValueNew, x => currentValueNew = x, 0, 0.05f).SetEase(Ease.Linear).OnUpdate(() =>
      {
          perlinNoise.m_AmplitudeGain = currentValueNew;
      }).SetDelay(0.15f);
    }
}
