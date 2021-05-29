using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimDatabase : IAnimDatabase
{
    private const string UnitAnimConfigsLocation = "UnitsAnimationReferences";
    private UnitsAnimationReference[] unitAnims;

    [PostConstruct]
    private void Initialize()
    {
        var unitConfigObject = Resources.Load<UnitsAnimationReferences>(UnitAnimConfigsLocation);

        if (unitConfigObject)
        {
            unitAnims = unitConfigObject.animationReferences;
        }
        else
        {
            Debug.Log($"Failed loading config by path {UnitAnimConfigsLocation}");
        }
    }

    public UnitsAnimationReference Get(int id)
    {
        foreach (var config in unitAnims)
        {
            if (config.AnimID == id)
            {
                return config;
            }
        }

        return UnitsAnimationReference.Null;
    }
}