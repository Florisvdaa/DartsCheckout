using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasButton : MonoBehaviour
{
    public CanvasState targetState;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            CanvasManager.Instance.SetState(targetState);
        });
    }
}
