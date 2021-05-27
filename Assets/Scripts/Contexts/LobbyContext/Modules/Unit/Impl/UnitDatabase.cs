using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UnitDatabase : IUnitDatabase
{
    private const string UnitConfigLocation = "UnitsConfigurations";
    private UnitConfiguration[] unitConfigurations;

    public IReadOnlyList<UnitConfiguration> UnitConfigurations => unitConfigurations.ToList();

    [PostConstruct] 
    private void Initialize()
    {
        var unitConfigObject = Resources.Load<UnitConfigurations>(UnitConfigLocation);

        if (unitConfigObject)
        {
            unitConfigurations = unitConfigObject.unitConfigurations;
        }
        else
        {
            Debug.Log($"Failed loading config by path {UnitConfigLocation}");
        }
    }

    public UnitConfiguration Get(int id)
    {
        foreach(var config in unitConfigurations)
        {
            if(config.Id == id)
            {
                return config;
            }
        }

        return UnitConfiguration.Null;
    }
}
