using strange.extensions.context.api;
using System.Collections.Generic;
using System;

using UnityEngine;

public class UnitController : IUnitController
{
    private static UnitController _instance;
    private List<UnitModel> _models;

    public event Action<UnitModel> NewModelReceived;

    public static IUnitController Instance => _instance;

    public IReadOnlyList<UnitModel> Models => _models;

    [Inject(ContextKeys.CONTEXT_VIEW)] public GameObject ContextRoot { get; set; }

    public void Initialize(UnitModel model)
    {
        _models = new List<UnitModel>(6);
        _models.Add(model);
    }

    public void Update(float deltaTime)
    {
    }

    public void AddModel(UnitModel model)
    {
        _models.Add(model);
    }
}