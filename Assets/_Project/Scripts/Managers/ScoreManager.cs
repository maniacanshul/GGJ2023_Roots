using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
   private int _currentScore = 0;
   private int _enemiesLeft = 100;
   [SerializeField] private TextMeshProUGUI scoreText;

   private void Awake()
   {

      GameManager.PlayerScored += IncreaseScore;
      GameManager.SplitEnemy += (enemy) =>
      {
         _enemiesLeft -= enemy.isParent ? 1 : 0;
      };
   }

   private void IncreaseScore(int amt, int multiplier)
   {
      // _currentScore += amt * multiplier;
      // scoreText.text = $"Score : {_currentScore}";
   }
}
