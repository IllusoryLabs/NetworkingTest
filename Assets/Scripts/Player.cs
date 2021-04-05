using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{

    public float sensitivity = 0.5f;
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

    private void FixedUpdate()
    {
        HandleMovement();
    }
}
