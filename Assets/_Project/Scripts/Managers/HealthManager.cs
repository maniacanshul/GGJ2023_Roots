using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthManager : MonoBehaviour
{
    private int _currentHealth;
    [SerializeField] private Image healthBar;
    [SerializeField] private int maxHealth, minHealth;
    void Awake()
    {
        GameManager.PlayerHit += TakeDamage;
        _currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void TakeDamage(int dmg)
    {
        _currentHealth -= dmg;
        ClampHealth();
        UpdateHealthBar();
        if (_currentHealth == 0)
        {
            GameManager.instance.OnPlayerDied();
        }
    }

    public void RegenerateHealth(int amt)
    {
        _currentHealth += amt;
        ClampHealth();
        UpdateHealthBar();
    }

    private void ClampHealth()
    {
        Mathf.Clamp(_currentHealth, minHealth, maxHealth);
    }

    private void UpdateHealthBar()
    {
        healthBar.DOFillAmount(_currentHealth / 100.0f, 0.15f).SetEase(Ease.InOutBack);
    }
}
