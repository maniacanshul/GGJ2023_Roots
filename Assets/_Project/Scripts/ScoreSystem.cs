using System;
using System.Collections;
using System.Collections.Generic;
using Supyrb;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int _currentScore = 0;
    private void Awake()
    {
        GameManager.Instance.PlayerScored += AddScore;
    }

    private void AddScore(int score, int multiplier)
    {
        _currentScore += score * multiplier;
    }
}
