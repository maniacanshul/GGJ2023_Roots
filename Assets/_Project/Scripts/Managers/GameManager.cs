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
    public static Action<int, int, Transform> SplitEnemy;

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

    public void OnSplitEnemy(int power, int count, Transform enemyTransform)
    {
        SplitEnemy?.Invoke(power, count, enemyTransform);
        comboMeter.EnemySucessfullyHit();
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
