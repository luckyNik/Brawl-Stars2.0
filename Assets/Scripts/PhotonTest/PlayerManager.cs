using System;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviourPun, IPunObservable
{ 

    public static GameObject LocalPlayerInstance;
    public static event Action<GameObject> LocalPlayerInstanceCreated;

    private UnitModel _model;

    public bool IsMine { get; private set; }

    
    
    public void Initialize(UnitModel model)
    {
        _model = model;

        model.Nickname = PhotonNetwork.NickName;
        model.UserId = PhotonNetwork.LocalPlayer.UserId;
    }

    private void Start()
    {
        if (photonView.IsMine)
        {
            IsMine = true;
            LocalPlayerInstance = gameObject;
            LocalPlayerInstanceCreated?.Invoke(LocalPlayerInstance);
        }
        else
        {
            var model = new UnitModel(transform.position, GetComponent<CharacterController>().bounds.size, 0); // implement normal id setting
            //UnitController.AddModel(model);
        }

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode loadingMode)
    {
        // check if we are outside the Arena and if it's the case, spawn around the center of the arena in a safe zone
        if (!Physics.Raycast(transform.position, -Vector3.up, 5f))
        {
            transform.position = new Vector3(0f, 5f, 0f);
        }
    }

    public void OnDisable()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            if (IsMine)
            {
                string serializedModel = JsonUtility.ToJson(_model.SerializableModel);

                Debug.Log("Model to send: \n" + serializedModel);

                stream.SendNext(serializedModel);
            }
        }
        else
        {
            if (!IsMine)
            {
                string serializedModel = (string)stream.ReceiveNext();

                Debug.Log("Received model: \n" + serializedModel);

                if(_model == null)
                {
                    _model = new UnitModel();
                    _model.SerializableModel = JsonUtility.FromJson<SerializableUnitModel>(serializedModel);
                    UnitController.Instance.AddModel(_model);
                }
                else
                {
                    _model.SerializableModel = JsonUtility.FromJson<SerializableUnitModel>(serializedModel);
                }
            }
        }
    }
}