using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private TMP_Text powerText;
    public ScriptableObjectNumbersGenerator enemyPowerData;
    public int power;

    public bool isParent = false;
    public int Health { get; private set; } = 64;
    public int Damage { get; private set; }

    public int Count { get; private set; } = 2;

    private void Awake()
    {
        powerText = GetComponentInChildren<TMP_Text>();
    }

    public void SetPower(int power)
    {
        this.power = power;
        Health = this.power;
        Damage = this.power;
        Count = IsSqrt() ? 2 : 3;
        powerText.text = power.ToString();

    }

    public bool IsSqrt()
    {
        return enemyPowerData.IsNumberAPerfectSquare(power);
    }

    public bool IsCubeRoot()
    {
        return enemyPowerData.IsNumberAPerfectCube(power);
    }

    public void TakeDamage((int, Weapon_Type) data) // item1 - dmgValue, Item2 - weaponIndex
    {
        if (data.Item2 == Weapon_Type.SquareRoot && IsSqrt())
        {
            Health -= data.Item1;
            Health = Mathf.Max(0, Health);
        }
        else if (data.Item2 == Weapon_Type.CubeRoot && IsCubeRoot())
        {
            Health -= data.Item1;
            Health = Mathf.Max(0, Health);
        }
        else
        {
            GameManager.instance.OnEnemyWrongHit();
        }
    }
}
