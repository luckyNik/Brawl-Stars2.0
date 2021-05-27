using UnityEngine;
using System;

 [CreateAssetMenu(fileName = "UnitsAnimationReferences", menuName = "Scriptable Data/UnitsAnimationReferences")]
public class UnitsAnimationReferences : ScriptableObject
{
    public UnitsAnimationReference[] animationReferences;

    public UnitsAnimationReference GetBySkinId(int id)
    {
        foreach(UnitsAnimationReference animReference in animationReferences)
        {
            if(animReference.AnimID == id)
            {
                return animReference;
            }
        }
        return UnitsAnimationReference.Null;
    }
}

 [Serializable]
public class UnitsAnimationReference
{
    public static UnitsAnimationReference Null
    {
        get
        {
            return new UnitsAnimationReference
            {
                Model = null,
                PhotonViewModel = null,
                AnimID = 0
            };
        }
    }

    public GameObject Model;
    public GameObject PhotonViewModel;
    public int AnimID;
}