using UnityEngine;

namespace GGJ.Enemies.Actions
{
    [CreateAssetMenu(menuName = "Enemies/Actions/Chase")]
    public class ChaseAction : Action
    {
        public override void Act(StateController controller)
        {
            Chase(controller);
        }

        private void Chase(StateController controller){
            controller.navMeshAgent.destination = controller.chaseTarget.position;
            controller.navMeshAgent.isStopped = false;
        }
    }    
}