using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.InputSystem;
public class CharacterMovement : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterController controller=null;

    [Header("Settings")]
    [SerializeField] private float movementSpeed=5f; 

    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) {return;}
        var movement = new Vector3();
        if (Keyboard.current.wKey.isPressed) {movement.z+=1;}
        if (Keyboard.current.sKey.isPressed) {movement.z-=1;}
        if (Keyboard.current.aKey.isPressed) {movement.x-=1;}
        if (Keyboard.current.dKey.isPressed) {movement.x+=1;}

        controller.Move(movement * movementSpeed * Time.deltaTime);
        if (controller.velocity.magnitude > 0.2f) {
            transform.rotation=Quaternion.LookRotation(movement);
        }
        

    }
}
