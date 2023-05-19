using System.Collections.Generic;
using UnityEngine;
using System;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    public Action<GameStates> StateChange;
    
    public GameStates currentState;

    private void Awake()
    {
        instance = this;        
    }

    public void OnGameStateChange(GameStates gameStates)
    {
        currentState = gameStates;
        StateChange?.Invoke(currentState);
    }    
}

public enum GameStates
{
    Menu,
    Play,
    Pause,
    GameOver,
}
