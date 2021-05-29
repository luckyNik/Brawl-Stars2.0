using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnitDatabase
{
    IReadOnlyList<UnitConfiguration> UnitConfigurations { get; }
    UnitConfiguration Get(int id);
}