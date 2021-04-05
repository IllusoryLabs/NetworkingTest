using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkMnanager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("Server Start");
        base.OnStartServer();
    }

    public override void OnStopServer()
    {
        Debug.Log("Server Stop");
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client Connected to Server");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Client Disconnected from Server");
    }
}
