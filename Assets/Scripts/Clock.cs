using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [Header("TIME")]

    [SerializeField]
    private float _dayDuration; // day time duration in seconds (06:00 - 00:00)

    [SerializeField]
    private TextMeshProUGUI _timeText;

    private bool _isDay = true;
    public bool IsDay
    {
        get { return _isDay; }
    }

    private float _currentTime = 6f * 3600f; // Start time 6a.m.
    private float _timeMultiplier;

    public static Clock Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _timeMultiplier = 24f * 3600f / _dayDuration; // calculate time multiplier
    }

    private void Update()
    {
        UpdateTime();
        UpdateTimeText();
    }

    private void UpdateTime()
    {
        float timeIncrement = Time.deltaTime * _timeMultiplier;
        _currentTime += timeIncrement;

        if (_currentTime >= 24f * 3600f) 
        {
            _currentTime -= 24f * 3600f;
        }

        
        if (!_isDay && _currentTime >= 6f * 3600f - timeIncrement && _currentTime < 6f * 3600f)
        {
            SwitchToDay();
        }
        else if (_isDay && _currentTime >= 24f * 3600f - timeIncrement)
        {
            SwitchToNight();
        }
    }

    private void UpdateTimeText()
    {
        int hours = Mathf.FloorToInt(_currentTime / 3600f);
        int minutes = Mathf.FloorToInt((_currentTime % 3600f) / 60f);

        string timeString = string.Format("{0:00}:{1:00}", hours, minutes);

        _timeText.text = "Time: " + timeString;
    }

    private void SwitchToDay()
    {
        _isDay = true;
    }

    private void SwitchToNight()
    {
        _isDay = false;
    }
}