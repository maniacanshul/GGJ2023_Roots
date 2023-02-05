using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ComboMeter : MonoBehaviour
{
    [SerializeField] private Image comboMeter;
    [SerializeField] private HealthManager healthManager;

    private float currentComboValue = 0;

    private float maxComboValue = 100;
    private float comboDepltionRatePerFrame = 0.01f;
    private float comboAdditionOnEnemyHit = 80;

    public void EnemySucessfullyHit()
    {
        currentComboValue += comboAdditionOnEnemyHit;
        ClampComboMeterValue();
        if (Mathf.Abs(currentComboValue - maxComboValue) < 1)
        {
            healthManager.RegenerateHealth(10);
            currentComboValue = 0;
        }
    }

    public void EnemyHitUnsucessfully()
    {
        currentComboValue = 0;
    }

    private void ClampComboMeterValue()
    {
        currentComboValue = Mathf.Clamp(currentComboValue, 0, maxComboValue);
    }

    private void Update()
    {
        currentComboValue -= comboDepltionRatePerFrame;
        ClampComboMeterValue();
        UpdateHUD();
    }

    private void UpdateHUD()
    {
        comboMeter.fillAmount = currentComboValue / maxComboValue;
    }
}
