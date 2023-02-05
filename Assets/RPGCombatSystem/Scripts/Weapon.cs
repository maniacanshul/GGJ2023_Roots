using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int dmgValue = 132; //Damage of the weapon
    public Color dmgColor = Color.cyan; //Color of the text with the damage value
    public Weapon_Type weaponType;


    private BoxCollider coll; //Collider of the weapon

    void Awake()
    {
        coll = GetComponent<BoxCollider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.tag == "Enemy")
        {
            other.SendMessage("TakeDamage", (dmgValue, weaponType));
        }
    }

    public void EnableColliders() //Called from the AnimatorEvent script
    {
        coll.enabled = true;
    }

    public void DisableColliders() //Called from the AnimatorEvent script
    {
        coll.enabled = false;
    }
}

public enum Weapon_Type
{
    SquareRoot,
    CubeRoot,
    Normal
}
