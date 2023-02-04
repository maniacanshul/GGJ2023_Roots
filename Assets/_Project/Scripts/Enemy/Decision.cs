using UnityEngine;

namespace GGJ.Enemies
{
    public abstract class Decision : ScriptableObject {
        public abstract bool Decide(StateController controller);
    }
}