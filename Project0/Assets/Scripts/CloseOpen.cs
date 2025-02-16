using UnityEngine;

public class CloseOpen : MonoBehaviour
{
    [Header("Windows")]
    public GameObject TimerWindow;
    
    public void CloseWindow()
    {
        TimerWindow.SetActive(false);
    }

    public void OpenWindow()
    {
        TimerWindow.SetActive(true);
    }
}
