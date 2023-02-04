using UnityEngine;

namespace GGJ.Enemies.Decisions 
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/PlayerInRangeDecision")]
    public class PlayerInRangeDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            RaycastHit hit;
            Vector3 position = controller.transform.position;
            Vector3 direction = controller.transform.forward;
            float lookRange = controller.enemyData.viewDistance;

            Debug.DrawRay(position, direction.normalized * lookRange, Color.green);

            if (Physics.SphereCast(position, lookRange, direction, out hit, controller.enemyData.maxChaseDistance) && hit.collider.CompareTag("Player"))
            {
                controller.chaseTarget = hit.transform;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}