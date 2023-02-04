using UnityEngine;

namespace GGJ.Enemies.Decisions
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/AndDecision")]
    public class AndDecision : Decision
    {
        [SerializeField] private Decision[] m_decisions;
        public override bool Decide(StateController controller)
        {
            bool result = true;
            foreach (var d in m_decisions)
            {
                result = result && d.Decide(controller);
            }
            return result;
        }
    }
}