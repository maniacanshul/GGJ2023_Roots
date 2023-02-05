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


    void SplitEnemy(EnemyManager enemy)
    {
        Debug.Log("Works");
        switch (enemy.Count)
        {
            case 2:
                SpawnTwoEnemies(enemy);
                break;
            case 3:
                SpawnThreeEnemies(enemy);
                break;
            default:
                break;
        }
    }

    private void SpawnTwoEnemies(EnemyManager parent)
    {
        var e1 = Instantiate(enemyPrefab, parent.transform.position + new Vector3(2,0,0), parent.transform.rotation);
        var e2 = Instantiate(enemyPrefab, parent.transform.position + new Vector3(-2,0,0), parent.transform.rotation);
        var man1 = e1.GetComponent<EnemyManager>();
        var man2 = e2.GetComponent<EnemyManager>();
        var stc1 = e1.GetComponent<StateController>();
        var stc2 = e2.GetComponent<StateController>();

        var parentIndex = parent.parentPower == -1 ? parent.power : parent.parentPower;
        man1.SetPower((int)Mathf.Sqrt(parent.power),parentIndex);
        man2.SetPower((int)Mathf.Sqrt(parent.power),parentIndex);
        
        stc1.wayPointList = this.wayPointList;
        stc2.wayPointList = this.wayPointList;
        
        if(GameManager.instance.enemyList.ContainsKey(parentIndex))
        {
            GameManager.instance.enemyList[parentIndex] += 2;
        }
        else
        {
            GameManager.instance.enemyList[parentIndex] = 2;

        }
    }

    private void SpawnThreeEnemies(EnemyManager parent)
    {
        var e1 = Instantiate(enemyPrefab, parent.transform.position + new Vector3(3,0,0), parent.transform.rotation);
        var e2 = Instantiate(enemyPrefab, parent.transform.position + new Vector3(0,0,0), parent.transform.rotation);
        var e3 = Instantiate(enemyPrefab, parent.transform.position + new Vector3(-3,0,0), parent.transform.rotation);
        
        var man1 = e1.GetComponent<EnemyManager>();
        var man2 = e2.GetComponent<EnemyManager>();
        var man3 = e3.GetComponent<EnemyManager>();
        
        var stc1 = e1.GetComponent<StateController>();
        var stc2 = e2.GetComponent<StateController>();
        var stc3 = e3.GetComponent<StateController>();
        
        var parentIndex = parent.parentPower == -1 ? parent.power : parent.parentPower;

        
        man1.SetPower((int)Mathf.Sqrt(parent.power),parentIndex);
        man2.SetPower((int)Mathf.Sqrt(parent.power),parentIndex);
        man3.SetPower((int)Mathf.Sqrt(parent.power),parentIndex);
        
        stc1.wayPointList = this.wayPointList;
        stc2.wayPointList = this.wayPointList;
        stc3.wayPointList = this.wayPointList;
        
        if(GameManager.instance.enemyList.ContainsKey(parentIndex))
        {
            GameManager.instance.enemyList[parentIndex] += 2;
        }
        else
        {
            GameManager.instance.enemyList[parentIndex] = 2;

        }
    }
}
