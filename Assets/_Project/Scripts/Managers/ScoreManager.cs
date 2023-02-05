using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
   private int _currentScore = 0;
   private int _enemiesLeft = 36;
   public int enemiesLeft { get => _enemiesLeft; }
   
   [SerializeField] private TextMeshProUGUI objectiveText;

   private void Awake()
   {
      GameManager.EnemyDied += EnemyDead;

      EnemyDead();
   }

   private void IncreaseScore(int amt, int multiplier)
   {
      _currentScore += amt * multiplier;

   }

   private void EnemyDead()
   {
      _enemiesLeft--;
      objectiveText.text = $"Enemies Left : {_enemiesLeft} / 35";
   }
}
