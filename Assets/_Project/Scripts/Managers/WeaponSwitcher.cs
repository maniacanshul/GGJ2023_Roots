using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] playerCharSwordObjects;
    [SerializeField] private GameObject[] playerSwordUIIndicators;

    private int weaponIndex = 0; // 0 square root, 1 cube root

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            weaponIndex++;
            if (weaponIndex > 1)
            {
                weaponIndex = 0;
            }
            
            UpdateWeaponOnSwitching();
        }
    }

    private void UpdateWeaponOnSwitching()
    {
        for (int i = 0; i < playerCharSwordObjects.Length; i++)
        {
            playerCharSwordObjects[i].SetActive(i == weaponIndex);
            playerSwordUIIndicators[i].SetActive(i == weaponIndex);
        }
    }
}
