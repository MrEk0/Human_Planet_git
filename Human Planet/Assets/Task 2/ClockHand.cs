using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockHand : MonoBehaviour
{
    [SerializeField] Transform hourHand;
    [SerializeField] Transform minuteHand;
    [SerializeField] Transform secondHand;

    private float seconds = 360/60f;
    private float hour = 360 / 12f;
    // Update is called once per frame
    void Update()
    {
        //DateTime time = DateTime.Now;
        //secondHand.localRotation = Quaternion.Euler(0, 0, -time.Second*seconds);
        //minuteHand.localRotation = Quaternion.Euler(0, 0, -time.Minute * seconds);
        //hourHand.localRotation = Quaternion.Euler(0, 0, -time.Hour * hour);
        TimeSpan timespan = DateTime.Now.TimeOfDay;
        hourHand.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalHours * -hour);
        minuteHand.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalMinutes * -seconds);
        secondHand.localRotation =
            Quaternion.Euler(0f, 0f, (float)timespan.TotalSeconds * -seconds);
    }
}
