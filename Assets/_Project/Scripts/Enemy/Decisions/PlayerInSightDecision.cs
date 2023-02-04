using UnityEngine;

namespace GGJ.Enemies.Decisions 
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/PlayerInSightDecision")]
    public class PlayerInSightDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            return false;
        }
    }
}