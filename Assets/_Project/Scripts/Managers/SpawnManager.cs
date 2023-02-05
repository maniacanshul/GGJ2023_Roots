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

    void SplitEnemy(int power, int count, Transform enemy)
    {
        Debug.Log("Works");
        switch (count)
        {
            case 2:
                var e1 = Instantiate(enemyPrefab, enemy.position + new Vector3(2, 0, 0), enemy.rotation);
                e1.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e1.GetComponent<StateController>().wayPointList = this.wayPointList;
                var e2 = Instantiate(enemyPrefab, enemy.position + new Vector3(-2, 0, 0), enemy.rotation);
                e2.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e2.GetComponent<StateController>().wayPointList = this.wayPointList;
                break;
            case 3:
                var e3 = Instantiate(enemyPrefab, enemy.position + new Vector3(3, 0, 0), enemy.rotation);
                e3.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e3.GetComponent<StateController>().wayPointList = this.wayPointList;
                var e4 = Instantiate(enemyPrefab, enemy.position + new Vector3(0, 0, 0), enemy.rotation);
                e4.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e4.GetComponent<StateController>().wayPointList = this.wayPointList;
                var e5 = Instantiate(enemyPrefab, enemy.position + new Vector3(-3, 0, 0), enemy.rotation);
                e5.GetComponent<EnemyManager>().setPower((int)Mathf.Sqrt(power));
                e5.GetComponent<StateController>().wayPointList = this.wayPointList;
                break;
            default:
                break;
        }
    }
}
