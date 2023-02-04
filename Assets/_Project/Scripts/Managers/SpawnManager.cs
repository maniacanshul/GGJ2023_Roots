using System.Collections;
using System.Collections.Generic;
using GGJ.Enemies;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public List<Transform> wayPointList;
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
                var e1 = Instantiate(enemyPrefab, enemy.position + new Vector3(2,0,0), enemy.rotation);
                e1.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e1.GetComponent<StateController>().wayPointList = this.wayPointList;
                var e2 = Instantiate(enemyPrefab, enemy.position + new Vector3(-2,0,0), enemy.rotation);
                e2.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e2.GetComponent<StateController>().wayPointList = this.wayPointList;
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
