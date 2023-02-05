using System;
using System.Collections;
using System.Collections.Generic;
using GGJ.Utilities;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameTimer gameTimer;
    public ComboMeter comboMeter;

    public static Action<int> PlayerHit;
    public static Action PlayerDied;
    public static Action EnemyDied;

    public static Action<EnemyManager> SplitEnemy;

    private int _comboMultiplier = 0;
    private float _timeRemaining = 60;
    private bool _timerIsRunning = false;

    private void Start()
    {
        StartGame();
        enemyList = new Dictionary<int, int>();
    }

    public void StartGame()
    {
        gameTimer.StartTimer();
    }

    public void OnPlayerScored(int score)
    {
    }

    public void OnSplitEnemy(EnemyManager enemy)
    {
        comboMeter.EnemySucessfullyHit();
        SplitEnemy?.Invoke(enemy);
    }

    public void OnEnemyWrongHit()
    {
        comboMeter.EnemyHitUnsucessfully();
    }

    public void OnEnemyDied()
    {
        EnemyDied?.Invoke();
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

        _comboMultiplier = 0;
        _timerIsRunning = false;
    }
    
}
