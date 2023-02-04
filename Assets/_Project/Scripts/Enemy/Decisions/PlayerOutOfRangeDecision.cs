using UnityEngine;

namespace GGJ.Enemies.Decisions 
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/PlayerOutOfRangeDecision")]
    public class PlayerOutOfRangeDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            float distance = (controller.transform.position - controller.chaseTarget.position).sqrMagnitude;
            Debug.Log(distance);
            if (distance > controller.enemyData.maxChaseDistance * controller.enemyData.maxChaseDistance)
                return true;
            return false;
        }
    }
}