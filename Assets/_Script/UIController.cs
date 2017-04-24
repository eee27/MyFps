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

    [SerializeField]
    private GameObject UiBeforeGame;

    [SerializeField]
    private GameObject bloodBar;

    private bool isBag = false;
    private bool isBeforeUi = false;

    private Player playerScript;
    private EyesCamera playerScript2;
    private EyesCamera cameraScript;
    private AudioSource audioSource;

    private RectTransform blood;

    private void Awake()
    {
        playerScript = player.GetComponent<Player>();
        playerScript2 = player.GetComponent<EyesCamera>();
        cameraScript = player.transform.FindChild("Eyes Camera").GetComponent<EyesCamera>();
        audioSource = player.transform.FindChild("Eyes Camera").GetComponent<AudioSource>();
        blood = bloodBar.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
        ChangeUiBeforeGame();
    }

    private void Update()
    {
        timeText.text = (Time.timeSinceLevelLoad / 3600).ToString("#00") + ":" + (Time.timeSinceLevelLoad / 60).ToString("#00") + ":" + (Time.timeSinceLevelLoad % 60).ToString("#00");
        damageRateText.text = "Damage Rate: " + GlobalData.playerDamageRate;
        bloodText.text = "HP: " + GlobalData.blood;
        scoreText.text = GlobalData.playerScore.ToString();

        ChangeBloodBar();

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

    public void ChangeUiBeforeGame()
    {
        if (!isBeforeUi)
        {
            Time.timeScale = 0; UiBeforeGame.SetActive(true);
            isBeforeUi = true;
            playerScript.enabled = false;
            playerScript2.enabled = false;
            cameraScript.enabled = false;
            audioSource.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GlobalData.isUi = true;
        }
        else
        {
            Time.timeScale = 1; UiBeforeGame.SetActive(false);
            isBeforeUi = false;
            playerScript.enabled = true;
            playerScript2.enabled = true;
            cameraScript.enabled = true;
            audioSource.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GlobalData.isUi = false;
        }
    }

    private void ChangeBloodBar()
    {
        blood.sizeDelta = new Vector2(300 * (GlobalData.blood / 100f), blood.rect.height);
        blood.anchoredPosition3D = new Vector3(300 * (GlobalData.blood / 100f) / 2f, blood.localPosition.y, blood.localPosition.z);
    }
}