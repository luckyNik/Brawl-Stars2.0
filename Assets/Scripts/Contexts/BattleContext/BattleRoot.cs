using strange.extensions.context.impl;

public class BattleRoot : ContextView
{
    private void Awake()
    {
        var context = new BattleContext(this, true);
        context.Start();
    }
}
