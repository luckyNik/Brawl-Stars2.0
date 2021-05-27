using strange.extensions.command.impl;
using strange.extensions.context.api;

using UnityEngine;
using UnityEngine.EventSystems;

public class InitializeLobbyGUICommand : Command
{
    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }
    [Inject] public ILobbyController LobbyController { get; set; }
    [Inject] public ILobbyStateProvider  StateProvider { get; set; }

    public override void Execute()
    {
        LobbyController.Initialize();

        StateProvider.Model.PlayerLogin = "luckyNik77";

        var lobbyPrefab = Resources.Load<GameObject>("LobbyCanvasMV");

        GameObject.Instantiate<GameObject>(lobbyPrefab, ContextRoot.transform);
    }
}