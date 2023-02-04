using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private int _currentHealth;
    [SerializeField] private Slider healthBar;
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

    private void RegenerateHealth(int amt)
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
        healthBar.value = _currentHealth / 100.0f;
    }
}
