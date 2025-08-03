using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasState { Landing, Login, Create, Dashboard }

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }

    [SerializeField] private Transform canvasParent;

    private CanvasState currentState = CanvasState.Landing;
    private Dictionary<string, GameObject> canvasMap = new Dictionary<string, GameObject>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // Check if user is still logged into session

        CreateCanvasList(); // Gets all current canvasses

        DeactivateAllCanvas();
    }

    private void Start()
    {   
        ShowCanvas(currentState.ToString());
    }

    private void CreateCanvasList()
    {
        canvasMap.Clear();

        foreach (Transform child in canvasParent)
        {
            canvasMap[child.name] = child.gameObject;
        }
    }
    public void SetState(CanvasState newState)
    {
        currentState = newState;
        ShowCanvas(currentState.ToString());
    }

    public void ShowCanvas(string name)
    {
        DeactivateAllCanvas();

        if (canvasMap.TryGetValue(name, out var canvas))
        {
            canvas.SetActive(true);
        }
    }
    private void DeactivateAllCanvas()
    {
        foreach (var canvas in canvasMap.Values)
            canvas.SetActive(false);
    }
}
