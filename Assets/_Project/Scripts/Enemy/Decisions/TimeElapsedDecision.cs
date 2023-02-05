using UnityEngine;

namespace GGJ.Enemies.Decisions
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/TimeElapsed")]
    public class TimeElapsedDecision : Decision
    {
        public float minTimeToCheck = 2f;
        public float maxTimeToCheck = 4f;

        public override bool Decide(StateController controller)
        {
            return controller.stateTimeElapsed > Random.Range(minTimeToCheck, maxTimeToCheck);
        }
    }
}