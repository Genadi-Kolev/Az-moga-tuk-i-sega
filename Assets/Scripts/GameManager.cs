using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _m = 7, _n = 7;
    public int M
    {
        get => _m;
        set { if (value > 3 && value < 19) _m = value; }
    }
    public int N
    {
        get => _n;
        set { if (value > 3 && value < 19) _n = value; }
    }

    public static PlayerState PlayerState { get; private set; }

    private void OnEnable() => Queen.OnQueenPlaced += UpdateGameState;
    private void OnDisable() => Queen.OnQueenPlaced -= UpdateGameState;

    private void Awake()
    {
        PlayerState = PlayerState.Player1;
        DontDestroyOnLoad(gameObject);
    }

    private void UpdateGameState()
    {
        var enumState = (int) PlayerState * -1;
        PlayerState = (PlayerState)enumState;


        var deadCells = 0;
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

