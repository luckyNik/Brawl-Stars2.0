using UnityEngine;
using UnityEngine.Scripting;

public class GameObjectBindBridge : MonoBehaviour
{
    public bool gameObjectActive
    {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }
}