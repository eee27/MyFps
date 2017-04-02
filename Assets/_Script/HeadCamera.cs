using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//围绕targetPlayer进行旋转,并保持固定距离.
public class HeadCamera : MonoBehaviour
{
    [SerializeField]
    private Transform targetPlayer;

    public float rotSpeed = 4f;
    private float _rotX;
    private float _rotY;
    private Vector3 _offSet;

    private void Start()
    {
        _rotX = transform.eulerAngles.x;
        _rotY = transform.eulerAngles.y;
        _offSet = targetPlayer.position - transform.position;
    }

    private void LateUpdate()
    {
        float XInput = Input.GetAxis("Mouse X");
        float YInput = Input.GetAxis("Mouse Y");

        if (XInput != 0 || YInput != 0)
        {
            _rotX += YInput * rotSpeed;
            _rotY += XInput * rotSpeed;
        }
        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = targetPlayer.position - (rotation * _offSet);
        transform.LookAt(targetPlayer);
    }
}