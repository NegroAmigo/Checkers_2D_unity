using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState CurrentState;

    //public static event Action<GameState> OnGameStatusChange;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ChangeGameState(GameState.GenerateBoard);
    }

    public void ChangeGameState(GameState newState)
    {
        CurrentState = newState;
        switch (newState)
        {
            case GameState.GenerateBoard:
                GridManager.Instance.CreateGrid();
                break;
            case GameState.SpawnWhite:
                UnitManager.Instance.SpawnWhite();
                break;
            case GameState.SpawnBlack:
                UnitManager.Instance.SpawnBlack();
                break;
            case GameState.WhiteTurn:
                break;
            case GameState.BlackTurn:
                break;
            case GameState.ResultGame:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        //OnGameStatusChange?.Invoke(newState);
    }

}

public enum GameState
{

    GenerateBoard,
    SpawnWhite,
    SpawnBlack,
    WhiteTurn,
    BlackTurn,
    ResultGame
}
