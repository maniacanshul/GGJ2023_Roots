using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
   private int _currentScore = 0;
   private int _enemiesLeft = 100;
   [SerializeField] private TextMeshProUGUI objectiveText;

   private void Awake()
   {

      
      GameManager.EnemyDied += () =>
      {
         _enemiesLeft--;
         objectiveText.text = $"Questions Left : {_enemiesLeft}";
      };
   }

   private void IncreaseScore(int amt, int multiplier)
   {
      _currentScore += amt * multiplier;

   }
}
