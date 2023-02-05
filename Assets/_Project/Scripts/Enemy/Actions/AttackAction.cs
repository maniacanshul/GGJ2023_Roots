using UnityEngine;

namespace GGJ.Enemies.Decisions
{
    [CreateAssetMenu(menuName = "Enemies/Actions/Attack")]
    public class AttackAction : Action
    {
        public State returnState;
        public override void OnEnterState(StateController controller)
        {
            
        }

        public override void Act(StateController controller)
        {
            controller.navMeshAgent.destination = controller.chaseTarget.position;
            controller.navMeshAgent.isStopped = false;

            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance)
            {
                controller.navMeshAgent.isStopped = true;
                Attack(controller);
                controller.TransitionToState(returnState);
            }
        }

        private void Attack(StateController controller) {
            PlayerController pc = controller.chaseTarget.GetComponent<PlayerController> ();
            pc.ApplyDMG((controller.chaseTarget.position - controller.transform.position).normalized, Mathf.Sqrt(controller.EnemyManager.power));
        }
    }
}