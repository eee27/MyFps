using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gravity = 9.8f;
    public float speed = 5.0f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMove();
    }

    /*-----------------------------------------*/

    private void PlayerMove()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y -= gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _characterController.Move(movement);
    }
}