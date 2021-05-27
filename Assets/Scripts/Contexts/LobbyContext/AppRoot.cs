using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.context.impl;

public class AppRoot : ContextView
{
    private void Awake()
    {
        var context = new LobbyContext(this, true);
        context.Start();
    }
}
