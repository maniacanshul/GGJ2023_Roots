using UnityEngine;

namespace GGJ.Enemies
{
    [CreateAssetMenu(menuName = "Enemies/State")]
    public class State : ScriptableObject {
        public Action[] actions;
        public Transition[] transitions;

        public void UpdateState(StateController controller) {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(StateController controller) {
            foreach (var action in actions) action.Act(controller);
        }

        private void CheckTransitions(StateController controller) {
            foreach (var t in transitions)
            {
                bool decisionSucceded = t.decision.Decide(controller);

                if (decisionSucceded) controller.TransitionToState(t.trueState);
                else controller.TransitionToState(t.falseState);
            }
        }

        public void OnEnterState(StateController controller) {
            foreach (var action in actions) action.OnEnterState(controller);
        }

        public void OnExitState(StateController controller) {
            foreach (var action in actions) action.OnExitState(controller);
        }
    }
}