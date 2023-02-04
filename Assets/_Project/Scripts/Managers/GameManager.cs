using System;
using System.Collections;
using GGJ.Utilities;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action<int, int> PlayerScored;
    public static Action<int> PlayerHit; 
    public static Action PlayerDied;
    public static Action<int,int,Transform> SplitEnemy;

    private int _comboMultiplier = 0;
    private float _timeRemaining = 60;
    private bool _timerIsRunning = false;


    public void OnPlayerScored(int score)
    {
        if (!_timerIsRunning)
        {
            _timerIsRunning = true;
            _timeRemaining = 60;
            StartCoroutine(StartComboTimer());
        }
        else
        {
            _comboMultiplier++;
        }

        PlayerScored?.Invoke(score, (_comboMultiplier / 4) + 1);
    }

    public void OnSplitEnemy(int power, int count, Transform enemyTransform)
    {
        SplitEnemy?.Invoke(power,count,enemyTransform);
    }

    public void OnPlayerHit(int dmg)
    {
        PlayerHit?.Invoke(dmg);
    }

    public void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }

    IEnumerator StartComboTimer()
    {
        while (_timeRemaining>0)
        {
            _timeRemaining -= 1;
            yield return new WaitForSeconds(1);
        }

        _timerIsRunning = false;
    }

}
