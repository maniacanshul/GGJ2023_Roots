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

        [SerializeField] private GameObject m_bookStack;

        private Collider triggerCollider;
        private bool enemiesSpawned = false;
        
        public List<GameObject> enemies;

        private void Start() {
            m_bookStack.SetActive(false);

            triggerCollider = GetComponent<Collider>();
            enemiesSpawned = false;
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
                    manager.SetPower(power,-1);
                    GGJ.Enemies.StateController controller = newEnemy.GetComponent<GGJ.Enemies.StateController> ();
                    controller.wayPointList = spawnPoint.waypoints;
                    controller.waveSpawner = this;

                } else {
                    break;
                }
            }

            enemiesSpawned = true;
        }

        private void OnDestroy() {
            GameManager.instance.DestroyWaveSpawner(this);
        }

        public void AddEnemy(GameObject e) {
            enemies.Add(e);
        }

        public void DeleteEnemy(GameObject e) {
            enemies.Remove(e);
            if (enemies.Count == 0) {
                Destroy(m_bookStack);
                Destroy(this.gameObject);
            }
        }

        // when the player enters the collider
        private void OnTriggerExit(Collider other) {
            if (other.gameObject.CompareTag("Player")) {
                // enable the bookstack
                m_bookStack.SetActive(true);
                SpawnWave(mSpawnerData.maxEnemyPower);
                triggerCollider.enabled = false;
            }
        }


    }
}