using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonTestScript : MonoBehaviour
{
    [SerializeField] private Button testButton;
    [SerializeField] private TextMeshProUGUI log;

    private void Start()
    {
        testButton.onClick.AddListener(() => { LOG(); });
    }

    private void LOG()
    {
        log.text = "button is working";
    }
}
