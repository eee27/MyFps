using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text damageRateText;

    [SerializeField]
    private Text bloodText;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private GameObject bagObj;

    [SerializeField]
    private GameObject player;

    private bool isBag = false;

    private Player playerScript;
    private EyesCamera playerScript2;
    private EyesCamera cameraScript;
    private AudioSource audioSource;

    private void Start()
    {
        playerScript = player.GetComponent<Player>();
        playerScript2 = player.GetComponent<EyesCamera>();
        cameraScript = player.transform.FindChild("Eyes Camera").GetComponent<EyesCamera>();
        audioSource = player.transform.FindChild("Eyes Camera").GetComponent<AudioSource>();
    }

    private void Update()
    {
        timeText.text = (Time.timeSinceLevelLoad / 3600).ToString("#00") + ":" + (Time.timeSinceLevelLoad / 60).ToString("#00") + ":" + Time.timeSinceLevelLoad.ToString("#00");
        damageRateText.text = "Damage Rate: " + GlobalData.playerDamageRate;
        bloodText.text = "HP: " + GlobalData.blood + @"
" + "AC: " + GlobalData.armor;
        scoreText.text = "Score: " + GlobalData.playerScore;

        if (Input.GetKeyDown(KeyCode.B))
        {
            ChangeBagState();
        }
    }

    /*-----------------------------------------*/

    public void ChangeBagState()
    {
        if (!isBag)
        {
            Time.timeScale = 0; bagObj.SetActive(true);
            isBag = true;
            playerScript.enabled = false;
            playerScript2.enabled = false;
            cameraScript.enabled = false;
            audioSource.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1; bagObj.SetActive(false);
            isBag = false;
            playerScript.enabled = true;
            playerScript2.enabled = true;
            cameraScript.enabled = true;
            audioSource.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}