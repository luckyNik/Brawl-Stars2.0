using strange.extensions.command.impl;
using UnityEngine;
using strange.extensions.context.impl;

public class InitializeBattleGUICommand : Command
{
    private const string HeroCanvasPrefabLocation = "BattleUI/HeroCanvas";

    [Inject] public ILobbyStateProvider LobbyStateProvider { get; set; }
    [Inject] public IHeroMediator HeroMediator { get; set; }

    public override void Execute()
    {
        
    }
}