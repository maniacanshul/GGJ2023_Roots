using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[CreateAssetMenu()]
public class ScriptableObjectEnemySpawnerData : ScriptableObject
{
    public int maxEnemiesOnThisLevel;
    public List<EnemySpawnProbability> enemyData;

    [Header("Do Not Edit Manually, Use Populate Enemies Context Button to generate")]
    [ReadOnly] public List<Enemy_Type> enemiesForThisLevel;

    private int counter = 0;

    public Enemy_Type GetEnemyToSpawn()
    {
        return enemiesForThisLevel[counter++];
    }

    public bool HasAnyMoreEnemiesLeftInThisLevel()
    {
        return counter < enemiesForThisLevel.Count;
    }

    [ContextMenu("Populate Enemies")]
    public void GenerateEnemies()
    {
        enemiesForThisLevel.Clear();
        int normalEnemies = 0, squareEnemies = 0, cubeEnemies = 0;
        for (int i = 0; i < enemyData.Count; i++)
        {
            switch (enemyData[i].type)
            {
                case Enemy_Type.CUBE:
                    {
                        cubeEnemies += (int)(enemyData[i].probability * maxEnemiesOnThisLevel) / 100;
                        break;
                    }
                case Enemy_Type.SQUARE:
                    {
                        squareEnemies += (int)(enemyData[i].probability * maxEnemiesOnThisLevel) / 100;
                        break;
                    }
                case Enemy_Type.NORMAL:
                    {
                        normalEnemies += (int)(enemyData[i].probability * maxEnemiesOnThisLevel) / 100;
                        break;
                    }
            }
        }

        for (int i = 0; i < normalEnemies; i++)
        {
            enemiesForThisLevel.Add(Enemy_Type.NORMAL);
        }

        for (int i = 0; i < squareEnemies; i++)
        {
            enemiesForThisLevel.Add(Enemy_Type.SQUARE);
        }

        for (int i = 0; i < cubeEnemies; i++)
        {
            enemiesForThisLevel.Add(Enemy_Type.CUBE);
        }

        for (int i = 0; i < enemiesForThisLevel.Count; i++)
        {
            int j = Random.Range(0, i);
            Enemy_Type temp = enemiesForThisLevel[i];
            enemiesForThisLevel[i] = enemiesForThisLevel[j];
            enemiesForThisLevel[j] = temp;
        }

    }

    [System.Serializable]
    public class EnemySpawnProbability
    {
        public Enemy_Type type;
        [Range(0, 100)]
        public int probability;
    }
}

public enum Enemy_Type
{
    SQUARE,
    CUBE,
    NORMAL
}
