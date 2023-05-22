using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [Header("TIME")]
    [SerializeField]
    private float dayDuration; // day time duration in seconds (06:00 - 00:00)

    [SerializeField]
    private TextMeshProUGUI timeText;

    private bool isDay = true;
    private float currentTime = 6f * 3600f; // Start time 6a.m.
    private float timeMultiplier;

    private void Start()
    {
        timeMultiplier = 24f * 3600f / dayDuration; // calculate time multiplier
    }

    private void Update()
    {
        UpdateTime();
        UpdateTimeText();
    }

    private void UpdateTime()
    {
        float timeIncrement = Time.deltaTime * timeMultiplier;
        currentTime += timeIncrement;

        if (currentTime >= 24f * 3600f) 
        {
            currentTime -= 24f * 3600f;
        }

        
        if (!isDay && currentTime >= 6f * 3600f - timeIncrement && currentTime < 6f * 3600f)
        {
            SwitchToDay();
        }
        else if (isDay && currentTime >= 24f * 3600f - timeIncrement)
        {
            SwitchToNight();
        }
    }

    private void UpdateTimeText()
    {
        int hours = Mathf.FloorToInt(currentTime / 3600f);
        int minutes = Mathf.FloorToInt((currentTime % 3600f) / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);

        string timeString = string.Format("{0:00}:{1:00}", hours, minutes);

        timeText.text = "Time: " + timeString;
    }

    private void SwitchToDay()
    {
        isDay = true;
    }

    private void SwitchToNight()
    {
        isDay = false;
    }
}