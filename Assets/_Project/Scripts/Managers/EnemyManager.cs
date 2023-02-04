using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public ScriptableObjectNumbersGenerator enemyPowerData;
    public int power;
    public int health { get; private set; }
    public int damage { get; private set; }

    public void setPower(int power)
    {
        this.power = power;
        health = this.power;
        damage = this.power;
    }
    
    public bool IsSqrt()
    {
        return enemyPowerData.IsNumberAPerfectSquare(power);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        health = Mathf.Max(0, health);
    }
}
