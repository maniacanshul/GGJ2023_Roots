using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    void Awake()
    {
        GameManager.SplitEnemy += SplitEnemy;
    }

    void SplitEnemy(int power,int count, Transform enemy)
    {
        Debug.Log("Works");
        switch (count)
        {
            case 2:
                Instantiate(enemyPrefab, enemy.position + new Vector3(2,0,0), enemy.rotation);
                enemyPrefab.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                Instantiate(enemyPrefab, enemy.position + new Vector3(-2,0,0), enemy.rotation);
                enemyPrefab.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
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
