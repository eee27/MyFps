using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject ak47;

    [SerializeField]
    private GameObject usp;

    [SerializeField]
    private GameObject awp;

    [SerializeField]
    private GameObject deagle;

    private void Start()
    {
        setWeaponActive(false);
    }

    private void Update()
    {
        checkButton();
    }

    /*---------------------------------*/

    private void checkButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            setWeaponActive(ak47);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            setWeaponActive(usp);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            setWeaponActive(awp);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            setWeaponActive(deagle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            setWeaponActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void setWeaponActive(bool activeState)
    {
        ak47.SetActive(activeState);
        awp.SetActive(activeState);
        usp.SetActive(activeState);
        deagle.SetActive(activeState);
    }

    private void setWeaponActive(GameObject weapon)
    {
        ak47.SetActive(false);
        awp.SetActive(false);
        usp.SetActive(false);
        deagle.SetActive(false);

        weapon.SetActive(true);
    }
}