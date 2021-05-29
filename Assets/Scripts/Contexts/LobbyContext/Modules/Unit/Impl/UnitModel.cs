using System;

using UnityEngine;

public class UnitModel
{
    public int Health { get; set; }

    public int UnitId { get; private set; }

    public int SkinId { get; set; }

    public string UserId { get; set; }

    public string Nickname { get; set; }

    public Vector3 CurrentPosition { get; set; }

    public Vector3 Size { get; set; }

    public SerializableUnitModel SerializableModel
    {
        get => new SerializableUnitModel
        {
            UnitId = UnitId,
            SkinId = SkinId,
            UserId = UserId,
            Nickname = Nickname,
            CurrentPosition = CurrentPosition,
            Size = Size
        };
        set
        {
            UnitId = value.UnitId;
            SkinId = value.SkinId;
            UserId = value.UserId;
            Nickname = value.Nickname;
            CurrentPosition = value.CurrentPosition;
            Size = value.Size;
        }
    }

    

    public UnitModel()
    {
    }

    public UnitModel(Vector3 position, Vector3 size, int unitId)
    {
        UnitId = unitId;
        CurrentPosition = position;
        Size = size;
    }
}

 [Serializable]
 public struct SerializableUnitModel
{
    public int UnitId;
    public int SkinId;
    public int Health;
    public string UserId;
    public string Nickname;
    public Vector3 CurrentPosition;
    public Vector3 Size;
}