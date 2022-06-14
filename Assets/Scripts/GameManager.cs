using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _m = 7, _n = 7;
    public int m
    {
        get => _m;
        set { if (value > 3 && value < 13) _m = value; }
    }
    public int n
    {
        get => _n;
        set { if (value > 3 && value < 13) _n = value; }
    }

    public static PlayerState playerState = PlayerState.Player1;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void UpdateGameState()
    {
        int enumState = (int) playerState * -1;
        playerState = (PlayerState)enumState;


        int deadCells = 0;
        foreach (var tile in Grid.Instance.Tiles)
        {
            if (!tile.Available) deadCells++;
        }

        if (deadCells == Grid.Instance.Tiles.Length) SceneManager.LoadScene(2);
    }
}

public enum PlayerState
{
    Player1 = 1,
    Player2 = -1
}

