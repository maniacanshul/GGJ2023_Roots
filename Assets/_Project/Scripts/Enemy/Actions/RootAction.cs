using System;
using UnityEngine;

namespace GGJ.Enemies.Decisions
{
    [CreateAssetMenu(menuName = "Enemies/Actions/Root")]
    public class RootAction : Action
    {
        public override void OnEnterState(StateController controller)
        {
            if (controller.EnemyManager.IsSqrt())
            {
                GameManager.instance.OnSplitEnemy(controller.EnemyManager, controller.waveSpawner);
            }
            else if (controller.EnemyManager.IsCubeRoot())
            {
                GameManager.instance.OnSplitEnemy(controller.EnemyManager, controller.waveSpawner);
            }
            else
            {
                GameManager.instance.enemyList[controller.EnemyManager.parentPower]--;
                GameManager.instance.OnSplitEnemy(controller.EnemyManager, controller.waveSpawner);
                if (controller.EnemyManager.parentPower != -1)
                {
                    GameManager.instance.enemyList[controller.EnemyManager.parentPower]--;
                }
                Debug.Log($"Spawned two {Mathf.Sqrt(controller.EnemyManager.power)}");
            }

            if (controller.EnemyManager.parentPower != -1 && GameManager.instance.enemyList[controller.EnemyManager.parentPower] == 0)
            {
                GameManager.instance.OnEnemyDied();
            }
            GameManager.instance.OnPlayerScored(1);
            controller.waveSpawner.DeleteEnemy(controller.gameObject);
            Destroy(controller.gameObject);
        }

        public override void Act(StateController controller)
        {

        }
    }
}