using System;
using GGJ.Utilities;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public static event Action<int, int> PlayerScored;
    public static Action<int> PlayerHit; 
    public static Action PlayerDied;


    public void OnPlayerScored(int score, int multiplier)
    {
        PlayerScored?.Invoke(score, multiplier);
    }

    public void OnPlayerHit(int dmg)
    {
        Debug.Log("player hit");
        PlayerHit?.Invoke(dmg);
    }

    public void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }

}
