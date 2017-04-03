using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject topCamera;

    [SerializeField]
    private GameObject playerCamera;

    [SerializeField]
    private GameObject headCamera;

    private bool tempBool;
    private int cameraState;

    private void Start()
    {
        /*tempBool = true;
        playerCamera.SetActive(true);
        topCamera.SetActive(false);
        headCamera.SetActive(false);*/
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (tempBool)
            {
                topCamera.transform.GetChild(0).position = new Vector3(player.transform.position.x, player.transform.position.y + 10, player.transform.position.z);
                Time.timeScale = 0;
            }
            else { Time.timeScale = 1; }
            topCamera.SetActive(tempBool);
            playerCamera.SetActive(!tempBool);
            tempBool = !tempBool;
        }
    }
}