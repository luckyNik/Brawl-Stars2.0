using strange.extensions.context.impl;

using UnityEngine;

public class LobbyContext : MVCSContext
{
    public LobbyContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup)
    {
    }


    protected override void mapBindings()
    {
        injectionBinder.Bind<BattleSceneLoadedSignal>()
            .ToSingleton();

        injectionBinder.Bind<CharacterChoosenSignal>()
            .ToSingleton();

        injectionBinder.Bind<ILobbyController>()
            .Bind<ILobbyStateProvider>()
            .To<LobbyController>()
            .ToSingleton()
            .CrossContext();

        injectionBinder.Bind<IUnitDatabase>()
            .To<UnitDatabase>()
            .ToSingleton()
            .CrossContext();

        injectionBinder.Bind<IUnitController>()
            .To<UnitController>()
            .ToSingleton()
            .CrossContext();

        injectionBinder.Bind<IUnitAnimationDatabase>()
            .To<UnitAnimationDatabase>()
            .ToSingleton()
            .CrossContext();

        commandBinder.Bind<ContextStartSignal>()
            .To<InitializeLobbyGUICommand>()
            .InSequence()
            .Once();
    }
}