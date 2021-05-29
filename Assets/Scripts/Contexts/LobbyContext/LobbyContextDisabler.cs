using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.mediation.impl;

public class LobbyContextDisabler : View
{
    [Inject] public BattleSceneLoadedSignal BattleSceneLoadedSignal { get; set; }

    [PostConstruct] 
    private void Construct()
    {
        BattleSceneLoadedSignal.AddListener((scene) => gameObject.SetActive(false));
    }
}
