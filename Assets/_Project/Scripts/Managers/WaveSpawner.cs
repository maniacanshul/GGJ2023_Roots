using UnityEngine;
using System.Collections.Generic;

namespace GGJ.Managers
{
    [System.Serializable]
    public class SpawnPoint {
        public Transform point;
        public List<Transform> waypoints;
    }

    public class WaveSpawner : MonoBehaviour
    {
        [SerializeField] private ScriptableObjectNumbersGenerator m_numbers;
        [SerializeField] private ScriptableObjectEnemySpawnerData m_spawnerData;

        [SerializeField] private GameObject m_enemy;

        [SerializeField] private SpawnPoint[] m_spawnPoints;

        private void Start() {
            SpawnWave(m_spawnerData.maxEnemyPower);
        }

        private void SpawnWave(int maxPower) {
            while (true) {
                if (m_spawnerData.HasAnyMoreEnemiesLeftInThisLevel()) {
                    Enemy_Type type = m_spawnerData.GetEnemyToSpawn();
                    int power = 0;

                    switch (type) {
                        case Enemy_Type.CUBE : power = m_numbers.GetPerfectCube(maxPower); break;
                        case Enemy_Type.SQUARE : power = m_numbers.GetPerfectSquare(maxPower); break;
                        default : power = m_numbers.GetNormalNumber(maxPower); break;
                    }

                    SpawnPoint spawnPoint = m_spawnPoints[Random.Range(0, m_spawnPoints.Length)];
                    GameObject newEnemy = Instantiate(m_enemy, spawnPoint.point.position, Quaternion.identity, null);

                    EnemyManager manager = newEnemy.GetComponent<EnemyManager> ();
                    manager.setPower(power);
                    
                    GGJ.Enemies.StateController controller = newEnemy.GetComponent<GGJ.Enemies.StateController> ();
                    controller.wayPointList = spawnPoint.waypoints;

                } else {
                    break;
                }
            }
        }
    }
}