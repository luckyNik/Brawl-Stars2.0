using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyModel
{
    private LobbyState _state;

    public int CurrentUnitId
    {
        get => _state.CurrentUnitId;
        set
        {
            _state.CurrentUnitId = value;
        }
    }

    public string PlayerCharacter
    {
        get => _state.PlayerCharacter;

        set
        {
            _state.PlayerCharacter = value;
        }
    }

    public string PlayerLogin
    {
        get => _state.PlayerLogin;

        set
        {
            _state.PlayerLogin = value;
        }
    }

    public string GameMode
    {
        get => _state.GameMode;

        set
        {
            _state.GameMode = value;
        }
    }

    public LobbyModel(LobbyState state)
    {
        _state = state;
    }
}
