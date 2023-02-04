using UnityEngine;

namespace GGJ.Enemies.Decisions
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/TimeElapsed")]
    public class TimeElapsedDecision : Decision
    {
        public float timeToCheck = 2f;
        public override bool Decide(StateController controller)
        {
            return controller.stateTimeElapsed > timeToCheck;
        }
    }
}