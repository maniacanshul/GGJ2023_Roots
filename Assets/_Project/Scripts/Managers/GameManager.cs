using System;
using System.Collections;
using GGJ.Utilities;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameTimer gameTimer;
    public ComboMeter comboMeter;

    public static Action<int> PlayerHit;
    public static Action PlayerDied;

    public static Action<EnemyManager> SplitEnemy;

       private int _comboMultiplier = 0;
    private float _timeRemaining = 60;
    private bool _timerIsRunning = false;


    private void Start()
    {
        StartGame();
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

    public void OnPlayerHit(int dmg)
    {
        PlayerHit?.Invoke(dmg);
    }

    public void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }
}
