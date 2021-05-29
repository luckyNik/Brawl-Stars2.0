using strange.extensions.context.impl;

using UnityEngine;

public class BattleContext : MVCSContext
{
    public BattleContext(MonoBehaviour contextView, bool autoStartup)
        : base(contextView, autoStartup)
    {

    }

    protected override void mapBindings()
    {
        injectionBinder.Bind<IHeroMediator>()
            .To<HeroMediator>()
            .ToSingleton();

        injectionBinder.Bind<IUnitController>()
            .To<UnitController>()
            .ToSingleton();

        commandBinder.Bind<ContextStartSignal>()
           .To<InitializeBattleGUICommand>()
           .To<InitializeUnitsCommand>()  
           .InSequence()
           .Once();
    }
}
