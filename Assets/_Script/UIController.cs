using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    private void Start()
    {
    }

    private void Update()
    {
        timeText.text = (Time.timeSinceLevelLoad / 3600).ToString("#00") + ":" + (Time.timeSinceLevelLoad / 60).ToString("#00") + ":" + Time.timeSinceLevelLoad.ToString("#00");
    }
}