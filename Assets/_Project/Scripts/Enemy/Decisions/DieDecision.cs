using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ.Enemies.Decisions 
{
    [CreateAssetMenu(menuName = "Enemies/Decisions/DieDecision")]
    public class DieDecision : Decision
    {
        public override bool Decide(StateController controller)
        {
            if(controller.EnemyManager.Health == 0)
                return true;
            return false;
        }
    }

}