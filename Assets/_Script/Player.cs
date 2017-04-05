using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    public float gravity = 9.8f;
    public float speed = 5.0f;

    private CharacterController _characterController;
    private Animator anim;
    private Animator weaponAnim;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        weaponAnim = weapon.GetComponent<Animator>();
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

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            anim.SetBool("isRun", true);
            weaponAnim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
            weaponAnim.SetBool("isRun", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetBool("isReload", true);
            weaponAnim.SetBool("isReload", true);
        }
    }

    public void changeReload()
    {
        anim.SetBool("isReload", false);
        weaponAnim.SetBool("isReload", false);
    }
}