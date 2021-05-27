using System;

using UnityEngine;

[Serializable]
public class UnitModel
{
    public int Id;
    public int SkinId;
    public string Nickname;
    public Vector3 CurrentPosition;
    public Vector3 Size;

    public UnitModel()
    {
    }

    public UnitModel(Vector3 position, Vector3 size, int id)
    {
        Id = id;
        CurrentPosition = position;
        Size = size;
    }
}