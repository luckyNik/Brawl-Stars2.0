using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyController : ILobbyStateProvider, ILobbyController
{
    private LobbyModel _model;

    public LobbyModel Model => _model;

    [Inject] public CharacterChoosenSignal CharacterChoosenSignal { get; set; }

    public void Initialize()
    {
        _model = new LobbyModel(new LobbyState());

        CharacterChoosenSignal.AddListener(id => Model.CurrentUnitId = id); 
    }
}