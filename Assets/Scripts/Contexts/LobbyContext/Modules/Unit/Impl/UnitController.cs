using strange.extensions.context.api;
using System.Collections.Generic;

using UnityEngine;

public class UnitController : IUnitController
{
    private List<UnitModel> _models;

    public IReadOnlyList<UnitModel> Models => _models;

    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }
    [Inject] public IHeroMediator HeroMediator { get; set; }

    public void Initialize(UnitModel model)
    {
        _models = new List<UnitModel>(6);
        _models.Add(model);
    }

    public void AddModel(UnitModel model)
    {
        _models.Add(model);
        HeroMediator.Update(model);
    }

    public void Update(float deltaTime)
    {
    }
}