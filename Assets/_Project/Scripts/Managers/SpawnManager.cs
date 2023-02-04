using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    void Awake()
    {
        GameManager.splitEnemy += SplitEnemy;
    }

    void SplitEnemy(int count, Transform enemy)
    {
        switch (count)
        {
            case 2:
                Instantiate(enemyPrefab, enemy.position + new Vector3(2,0,0), enemy.rotation);
                Instantiate(enemyPrefab, enemy.position + new Vector3(-2,0,0), enemy.rotation);
                break;
            case 3:
                Instantiate(enemyPrefab, enemy.position + new Vector3(3,0,0), enemy.rotation);
                Instantiate(enemyPrefab, enemy.position + new Vector3(0,0,0), enemy.rotation);
                Instantiate(enemyPrefab, enemy.position + new Vector3(-3,0,0), enemy.rotation);
                break;
            default:
                break;
        }
    }
}
