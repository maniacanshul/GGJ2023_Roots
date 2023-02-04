using UnityEngine;

namespace GGJ.Enemies
{
    public abstract class Action : ScriptableObject {
        public virtual void OnEnterState(StateController controller) {}
        public virtual void OnExitState(StateController controller) {}
        public abstract void Act(StateController controller);
    }
}