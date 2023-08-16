using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetManager : MonoBehaviourPunCallbacks
{
    private void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        Connect();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        RoomOptions roomOptions = new RoomOptions();//RoomOptions는 Photon.Realtime에 있음
        roomOptions.MaxPlayers = 5;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("metaroom", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("룸 조인성 공");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
