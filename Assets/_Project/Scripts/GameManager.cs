using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("Game Manager is null");
            }

            return _instance;
        }
        
    }

    public event Action<int, int> PlayerScored;
    public event Action<int> PlayerHit; 

    void Awake()
    {
        _instance = this;
    }
    

    public void OnPlayerScored(int score, int multiplier)
    {
        PlayerScored?.Invoke(score, multiplier);
    }

    public void OnPlayerHit(int hit)
    {
        PlayerHit?.Invoke(hit);
    }
}
