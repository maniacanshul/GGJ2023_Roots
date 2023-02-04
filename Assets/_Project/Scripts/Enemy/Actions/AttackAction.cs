using UnityEngine;

namespace GGJ.Enemies.Decisions
{
    [CreateAssetMenu(menuName = "Enemies/Actions/Attack")]
    public class AttackAction : Action
    {
        public override void OnEnterState(StateController controller)
        {
            PlayerController pc = controller.chaseTarget.GetComponent<PlayerController> ();
            pc.ApplyDMG((controller.chaseTarget.position - controller.transform.position).normalized, 10f);
        }

        public override void Act(StateController controller)
        {
            
        }
    }
}