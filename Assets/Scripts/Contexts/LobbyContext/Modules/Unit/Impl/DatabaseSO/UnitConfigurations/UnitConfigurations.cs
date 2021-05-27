using UnityEngine;
using System;

[CreateAssetMenu(fileName = "UnitsConfigurations", menuName = "Scriptable Data/UnitsConfigurations")]
public class UnitConfigurations : ScriptableObject
{
    public UnitConfiguration[] unitConfigurations;
}

[Serializable]
public class UnitConfiguration
{
    public static UnitConfiguration Null
    {
        get
        {
            return new UnitConfiguration
            {
                Id = 0,
                SkinId = 0
            };
        }
    }

    public int Id;
    public int SkinId;
}