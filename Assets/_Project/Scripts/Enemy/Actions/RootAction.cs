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
                GameManager.instance.OnSplitEnemy(controller.EnemyManager.power, 2, controller.gameObject.transform);
            }
            else if (controller.EnemyManager.IsCubeRoot())
            {
                GameManager.instance.OnSplitEnemy(controller.EnemyManager.power, 3, controller.gameObject.transform);
            }
            else
            {
            }
            Destroy(controller.gameObject);
        }

        public override void Act(StateController controller)
        {

        }
    }
}