using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.impl;

public class ChangeCharacterCommand : Command
{
    public int UnitId { get; set; }

    [Inject] public ILobbyStateProvider StateProvider { get; set; }

    public override void Execute()
    {
        StateProvider.Model.CurrentUnitId = UnitId;
        Debug.Log("chosen");
    }
}
