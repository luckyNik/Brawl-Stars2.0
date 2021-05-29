using UnityEngine;

public class UnitAnimationDatabase : IUnitAnimationDatabase
{
    private const string UnitAnimationReferencesLocation = "UnitsAnimationReferences";

    private UnitsAnimationReferences _animationReferences;

    [Inject] public IUnitDatabase UnitDatabase { get; set; }

    [PostConstruct]
    private void Initialize()
    {
        _animationReferences = Resources.Load<UnitsAnimationReferences>(UnitAnimationReferencesLocation);
    }

    public UnitsAnimationReference GetById(int id)
    {
        int skinId = UnitDatabase.Get(id).SkinId;

        return GetBySkinId(skinId);
    }

    public UnitsAnimationReference GetBySkinId(int skinId) => _animationReferences.GetBySkinId(skinId);
}