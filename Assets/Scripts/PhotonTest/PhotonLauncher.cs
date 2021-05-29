using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    private const string GameVersion = "1";

    public static event Action OnSceneLoaded;

    [SerializeField] private byte _maxPlayersInRoom = 6;

    private bool isConnecting;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = GameVersion;
        }
    }

    public void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
        LobbyMV.PlayClicked += Connect;
    }

    public void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
        LobbyMV.PlayClicked -= Connect;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            isConnecting = false;
        }
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        isConnecting = false;
        Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        PhotonNetwork.CreateRoom(null,
                                new RoomOptions
                                {
                                    MaxPlayers = _maxPlayersInRoom
                                });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");

        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            Debug.Log("We load the 'Room for 1' ");

            PhotonNetwork.LoadLevel("Battle", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        }
    }
}
