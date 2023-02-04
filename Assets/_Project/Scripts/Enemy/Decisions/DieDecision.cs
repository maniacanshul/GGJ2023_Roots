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
            if(controller.EnemyManager.health == 0)
                return true;
            return false;
        }
    }

}