using strange.extensions.context.api;
using System.Collections.Generic;
using UnityEngine;

public class HeroMediator : IHeroMediator
{
    private const string HeroCanvasPrefabLocation = "BattleUI/HeroCanvas";

    private IReadOnlyList<UnitModel> _unitModels;
    private List<HeroMV> _heroes = new List<HeroMV>(6);

    private GameObject heroRoot;

    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextView { get; set; }

    public void Initialize(IReadOnlyList<UnitModel> unitModels)
    {
        _unitModels = unitModels;

        heroRoot = new GameObject("Heroes (UI)");
        heroRoot.transform.parent = ContextView.transform;

        foreach (var model in unitModels)
        {
            var heroCanvasPrefab = Resources.Load<GameObject>(HeroCanvasPrefabLocation);
            var heroCanvasInstance = GameObject.Instantiate(heroCanvasPrefab, heroRoot.transform);

            var heroMV = heroCanvasInstance.GetComponent<HeroMV>();
            heroMV.Initialize(model);

            _heroes.Add(heroMV);
        }
    }

    public void Update(UnitModel model)
    {
        var heroCanvasPrefab = Resources.Load<GameObject>(HeroCanvasPrefabLocation);
        var heroCanvasInstance = GameObject.Instantiate(heroCanvasPrefab, heroRoot.transform);

        var heroMV = heroCanvasInstance.GetComponent<HeroMV>();
        heroMV.Initialize(model);

        _heroes.Add(heroMV);
    }
}