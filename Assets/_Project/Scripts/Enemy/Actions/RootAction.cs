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
                GameManager.instance.OnSplitEnemy(controller.EnemyManager);
            }
            else if (controller.EnemyManager.IsCubeRoot())
            {
                GameManager.instance.OnSplitEnemy(controller.EnemyManager);
            }
            else
            {

                GameManager.instance.OnSplitEnemy(controller.EnemyManager);
                Debug.Log($"Spawned two {Mathf.Sqrt(controller.EnemyManager.power)}");
            }
            GameManager.instance.OnPlayerScored(1);
            Destroy(controller.gameObject);
        }

        public override void Act(StateController controller)
        {

        }
    }
}