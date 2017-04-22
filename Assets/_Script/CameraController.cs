using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject playerCamera;

    [SerializeField]
    private GameObject topCamera;

    private bool tempBool;
    private int cameraState;

    private Camera _topCamera;

    private void Start()
    {
        _topCamera = topCamera.GetComponent<Camera>();
    }

    private void Update()
    {
    }

    /*---------------------------------------------*/

    public void TopMapBig()
    {
        _topCamera.orthographicSize += 1;
    }

    public void TopMapSmall()
    {
        _topCamera.orthographicSize -= 1;
    }
}