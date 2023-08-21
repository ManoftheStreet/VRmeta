using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

[System.Serializable]

public class Room
{
    public string name;
    public int sceneNumber;
}

public class NetManager : MonoBehaviourPunCallbacks
{
    public List<Room> rooms;
    public GameObject uiRooms;


    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        //Connect();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        uiRooms.SetActive(true);
    }

    public void InitRoom(int iRoomNumber)
    {
        PhotonNetwork.LoadLevel(rooms[iRoomNumber].sceneNumber);

        RoomOptions roomOptions = new RoomOptions();//RoomOptions는 Photon.Realtime에 있음
        roomOptions.MaxPlayers = 5;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom(rooms[iRoomNumber].name, roomOptions, TypedLobby.Default);
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
