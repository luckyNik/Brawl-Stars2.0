using System.Collections.Generic;
using System;

public interface IUnitController
{
    event Action<UnitModel> NewModelReceived;

    IReadOnlyList<UnitModel> Models { get; }

    void Initialize(UnitModel model);
    void AddModel(UnitModel model);
}
