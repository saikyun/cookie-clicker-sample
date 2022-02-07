using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameState
{
    public int clicks = 0;
    public VisualElement hud;

    private static GameState _instance;

    public static GameState instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameState();
            }
            return _instance;
        }
    }
}
