using strange.extensions.command.impl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToBattleCommand : Command
{
    [Inject] public Scene BattleScene { get; set; }

    public override void Execute()
    {
        SceneManager.SetActiveScene(BattleScene);
    }
}
