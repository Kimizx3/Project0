using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    // TODO: Time Progress Bar UI
    // TODO: Real time translation
    // TODO: Single button to play/stop timer
    
    // Public:
    [FormerlySerializedAs("TimeSetterText")]
    [Header("Timer Elements")] 
    [SerializeField] public TextMeshProUGUI timeSetterText;
    [SerializeField] public TextMeshProUGUI breakTimeText;
    [SerializeField] public TextMeshProUGUI clockTxt;
    
    
    // Private:
    private const float IniTime = 5400;
    private const float IniBreakTime = 300;
    private float _currentTime = 5400;
    private float _workTime = 0;
    private float _breakTime = 300;
    private bool _timerStarted;
    private bool _timerStopped;
    private const float AMinute = 60f;
    
    // Protected:
    
    
    // Prototypes:
    /// public void PlayTimer();
    /// public void StopTimer();
    /// public void ResetTimer();
    /// public void ToggleTimerButton();
 
    /// private void DisplayTimer();
    /// private void DisplayTimeSetter();
    /// private void DisplayBreakTimeSetter();
    /// private void SetTime();
    /// private void GetMinutes();
    /// private void GetSeconds();
    /// private void PlusMinutesWorkTime();
    /// private void PlusMinutesBreakTime();
    /// private void MinusMinutesWorkTime();
    /// private void MinusMinutesBreakTime();
    private void OnEnable()
    {
        UIManager.OnStartClicked += PlayTimer;
        UIManager.OnStopClicked += StopTimer;
        UIManager.OnResetClicked += ResetTimer;
    }

    private void OnDisable()
    {
        UIManager.OnStartClicked -= PlayTimer;
        UIManager.OnStopClicked -= StopTimer;
        UIManager.OnResetClicked -= ResetTimer;
    }

    private void Start()
    {
        _timerStarted = false;
        _timerStopped = true;
        
        ResetTimer();
        _workTime = _currentTime;
        
        DisplayTimeSetter();
        DisplayBreakTimeSetter();
        DisplayTimer(_workTime);
    }

    private void Update()
    {
        if (_timerStarted)
        {
            _workTime -= Time.deltaTime;
            if (_workTime <= 0)
            {
                Debug.Log("Timer ended!");
                _timerStarted = false;
            }
            DisplayTimer(_workTime);
        }
        
        DisplayTimeSetter();
        DisplayBreakTimeSetter();
    }

    
    
    // TODO: create play and stop functions

    public void PlayTimer()
    {
        _timerStarted = true;
        _timerStopped = false;
    }

    public void StopTimer()
    {
        _timerStarted = false;
        _timerStopped = true;
    }
    
    public void ResetTimer()
    {
        _currentTime = IniTime;
        _breakTime = IniBreakTime;
        _workTime = _currentTime;
        DisplayTimer(_workTime);
        DisplayTimeSetter();
        DisplayBreakTimeSetter();
        _timerStarted = false;
    }
    
    
    // TODO: adjust timer functions (plus and minus) for workTime and breakTime

    private float SetTime(float newTime)
    {
        _currentTime = newTime;
        return _currentTime;
    }

    private float GetMinutes()
    {
        var minutes = Mathf.FloorToInt(_workTime / 60);
        return minutes;
    }

    private float GetSeconds()
    {
        var seconds = Mathf.FloorToInt(_workTime % 60);
        return seconds;
    }

    private void DisplayTimer(float workTime)
    {
        clockTxt.text = string.Format("{0:00}:{1:00}", GetMinutes(), GetSeconds());
    }

    private void DisplayTimeSetter()
    {
        var minuteText = Mathf.FloorToInt(_currentTime / 60);
        timeSetterText.text = string.Format("{00}", minuteText);
    }
    
    private void DisplayBreakTimeSetter()
    {
        var minuteText = Mathf.FloorToInt(_breakTime / 60);
        breakTimeText.text = string.Format("{00}", minuteText);
    }
    
    

    public void PlusMinutesWorkTime()
    {
        if (!_timerStarted)
        {
            _currentTime += AMinute;
            _workTime = _currentTime;
        }
        
    }

    public void MinusMinutesWorkTime()
    {
        if (!_timerStarted)
        {
            _currentTime -= AMinute;
            _workTime = _currentTime;
        }
        
    }
    
    public void PlusMinutesBreakTime()
    {
        if (!_timerStarted)
        {
            _breakTime += AMinute;
        }
        
    }

    public void MinusMinutesBreakTime()
    {
        if (_timerStarted)
        {
            _breakTime -= AMinute;
        }
        
    }
    
}
