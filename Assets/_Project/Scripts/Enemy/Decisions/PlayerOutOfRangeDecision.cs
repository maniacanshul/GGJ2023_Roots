using UnityEngine;

namespace GGJ.Enemies.Decisions 
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/PlayerOutOfRangeDecision")]
    public class PlayerOutOfRangeDecision : Decision
    {
        [SerializeField] private float m_distance = -1f;
        public override bool Decide(StateController controller)
        {
            float checkDistance = m_distance < 0f ? controller.enemyData.maxChaseDistance : m_distance;
            float distance = (controller.transform.position - controller.chaseTarget.position).sqrMagnitude;

            if (distance > checkDistance * checkDistance)
                return true;
            return false;
        }
    }
}