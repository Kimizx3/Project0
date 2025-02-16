using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{
    [Header("Buttons")]
    public Button StartButton;
    public Button StopButton;
    public Button ResetButton;

    public static event Action OnStartClicked;
    public static event Action OnStopClicked;
    public static event Action OnResetClicked;

    private void Start()
    {
        StartButton.onClick.AddListener(() => OnStartClicked?.Invoke());
        StopButton.onClick.AddListener(() => OnStopClicked?.Invoke());
        ResetButton.onClick.AddListener(() => OnResetClicked?.Invoke());
    }
}
