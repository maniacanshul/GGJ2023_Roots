using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

namespace GGJ.Managers
{
    [System.Serializable]
    public class SpawnPoint {
        public Transform point;
        public List<Transform> waypoints;
    }

    public class WaveSpawner : MonoBehaviour
    {
        [FormerlySerializedAs("m_numbers")] [SerializeField] private ScriptableObjectNumbersGenerator mNumbers;
        [FormerlySerializedAs("m_spawnerData")] [SerializeField] private ScriptableObjectEnemySpawnerData mSpawnerData;

        [FormerlySerializedAs("m_enemy")] [SerializeField] private GameObject mEnemy;

        [FormerlySerializedAs("m_spawnPoints")] [SerializeField] private SpawnPoint[] mSpawnPoints;

        private void Start() {
            SpawnWave(mSpawnerData.maxEnemyPower);
        }

        private void SpawnWave(int maxPower) {
            while (true) {
                if (mSpawnerData.HasAnyMoreEnemiesLeftInThisLevel()) {
                    Enemy_Type type = mSpawnerData.GetEnemyToSpawn();
                    int power = 0;

                    switch (type) {
                        case Enemy_Type.CUBE : power = mNumbers.GetPerfectCube(maxPower); break;
                        case Enemy_Type.SQUARE : power = mNumbers.GetPerfectSquare(maxPower); break;
                        default : power = mNumbers.GetNormalNumber(maxPower); break;
                    }

                    SpawnPoint spawnPoint = mSpawnPoints[Random.Range(0, mSpawnPoints.Length)];
                    GameObject newEnemy = Instantiate(mEnemy, spawnPoint.point.position, Quaternion.identity, null);

                    EnemyManager manager = newEnemy.GetComponent<EnemyManager> ();
                    manager.isParent = true;
                    manager.SetPower(power);
                    
                    GGJ.Enemies.StateController controller = newEnemy.GetComponent<GGJ.Enemies.StateController> ();
                    controller.wayPointList = spawnPoint.waypoints;

                } else {
                    break;
                }
            }
        }
    }
}