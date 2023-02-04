using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
   private int _currentScore = 0;
   [SerializeField] private TextMeshProUGUI scoreText;

   private void Awake()
   {
      GameManager.PlayerScored += IncreaseScore;
   }

   private void IncreaseScore(int amt, int multiplier)
   {
      _currentScore += amt * multiplier;
      scoreText.text = $"Score : {_currentScore}";
   }
}
