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
                Debug.Log("Enemy died");
            }
            else
            {
                GameManager.splitEnemy(2, controller.gameObject.transform);
                Debug.Log($"Spawned two {Mathf.Sqrt(controller.EnemyManager.power)}");
            }
            Destroy(controller.gameObject);
        }

        public override void Act(StateController controller)
        {
            
        }
    }
}