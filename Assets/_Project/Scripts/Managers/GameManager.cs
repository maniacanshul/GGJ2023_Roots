using System;
using System.Collections;
using System.Collections.Generic;
using GGJ.Utilities;
using UnityEngine;

using GGJ.Managers;

public class GameManager : Singleton<GameManager>
{
    public GameTimer gameTimer;
    public ComboMeter comboMeter;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWonPanel;

    [SerializeField] private List<WaveSpawner> _spawners;

    public static Action<int> PlayerHit;
    public static Action PlayerDied;
    public static Action EnemyDied;

    public static Action<EnemyManager, WaveSpawner> SplitEnemy;

    private int _comboMultiplier = 0;
    private float _timeRemaining = 60;
    private bool _timerIsRunning = false;
    public Dictionary<int, int> enemyList;

    private void Start()
    {
        StartGame();
        enemyList = new Dictionary<int, int>();

        _gameOverPanel.SetActive(false);
    }

    public void StartGame()
    {
        gameTimer.StartTimer();
    }

    public void DestroyWaveSpawner(WaveSpawner spawner) {
        _spawners.Remove(spawner);
        if (_spawners.Count == 0) {
            _gameWonPanel.SetActive(true);
        }
    }

    public void OnPlayerScored(int score)
    {
    }

    public void OnSplitEnemy(EnemyManager enemy, WaveSpawner waveSpawner)
    {
        comboMeter.EnemySucessfullyHit();
        SplitEnemy?.Invoke(enemy, waveSpawner);
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
        _gameOverPanel.SetActive(true);
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
