using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioClip reloadSound;

    [SerializeField]
    private Text pickText;

    [SerializeField]
    private GameObject cameraObj;

    [SerializeField]
    private GameObject easyColor;

    public float gravity = 9.8f;
    public float speed = 5.0f;

    private CharacterController _characterController;
    private Animator anim;
    private Animator weaponAnim;
    private Camera _camera;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        weaponAnim = weapon.GetComponent<Animator>();
        _camera = cameraObj.GetComponent<Camera>();
    }

    private void Update()
    {
        PlayerMove();
        PickableCheck();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
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
    }

    private void PickableCheck()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "Pickable" && (Vector3.Distance(transform.position, hit.point) <= 3f))
            {
                pickText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Instantiate(easyColor, hit.transform, false);
                    if (GlobalData.playerDamageRate <= 2f)
                    {
                        GlobalData.playerDamageRate += 0.1f;
                    }
                }
            }
            else
            {
                pickText.gameObject.SetActive(false);
            }
        }
    }
}