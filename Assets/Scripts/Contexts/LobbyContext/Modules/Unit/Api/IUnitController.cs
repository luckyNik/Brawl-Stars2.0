using System.Collections.Generic;

public interface IUnitController
{
    IReadOnlyList<UnitModel> Models { get; }

    void Initialize(UnitModel model);
    void Update(float deltaTime);
    void AddModel(UnitModel model);
}
