using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{

    public float sensitivity = 0.5f;
    [SyncVar(hook = nameof(onHolaCountChanged))]
    public int HolaCount = 0;

    void HandleMovement()
    {
        if (isLocalPlayer)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * sensitivity, moveVertical * sensitivity, 0);
            transform.position = transform.position + movement;
        }
    }

    private void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Hola();
            Debug.Log("Sending 'Hello!' to Server");
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    [Command]
    void Hola()
    {
        Debug.Log("Recieved 'Hello!' from Client");
        HolaCount = +1;
        replyHola();
    }

    [TargetRpc]
    void replyHola()
    {
        Debug.Log("Recieved 'Hello!' from Server");
    }

    void onHolaCountChanged(int oldCount, int newCount)
    {
        Debug.Log($"'Hello!'s changed from {oldCount} to {newCount}");
    }
}
