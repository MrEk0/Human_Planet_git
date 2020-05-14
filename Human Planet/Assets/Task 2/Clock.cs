using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] Transform hourHand;
    [SerializeField] Transform minuteHand;
    [SerializeField] Transform secondHand;

    private const float SECONDS_TO_DEGREE = 360 / 60f;
    private float MINUTES_TO_DEGREE = 360 / 60f;
    private float HOURS_TO_DEGREE = 360 / 12f;

    void Update()
    {
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        hourHand.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -HOURS_TO_DEGREE);
        minuteHand.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -MINUTES_TO_DEGREE);
        secondHand.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -SECONDS_TO_DEGREE);
    }
}
