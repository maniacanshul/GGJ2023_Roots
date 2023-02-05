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
    public int health { get; private set; } = 64;
    public int damage { get; private set; } = 5;


    private void Awake()
    {
        powerText = GetComponentInChildren<TMP_Text>();
    }

    public void setPower(int power)
    {
        this.power = power;
        powerText.text = power.ToString();
        // health = this.power;
        // damage = this.power;
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
            health -= data.Item1;
            health = Mathf.Max(0, health);
        }
        else if (data.Item2 == Weapon_Type.CubeRoot && IsCubeRoot())
        {
            health -= data.Item1;
            health = Mathf.Max(0, health);
        }
    }
}
