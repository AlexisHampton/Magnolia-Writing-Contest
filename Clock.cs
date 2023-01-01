using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

class ClockTime
{
    int hours;
    int minutes;
    public int Hours { get { return hours; } }

    public ClockTime()
    {
        hours = 0;
        minutes = 0;
    }

    public void UpdateTime(int h, int m)
    {

        minutes = m % 60;
        hours = h + m / 60;
    }

    public override string ToString()
    {
        string timeString = hours + ":";
        if (minutes == 0) return timeString + "0" + minutes;
        return timeString + minutes;

    }
}

public class Clock : Singleton<Clock>
{
    public int hoursLeft = 6;
    public TextMeshProUGUI clockTimeText;

    ClockTime clockTime = new ClockTime();

    public void ResetTime()
    {
        hoursLeft = 6;
        clockTime.UpdateTime(6, 0);
        clockTimeText.text = clockTime.ToString();
    }

    public void PassTime(int hours)
    {
        hoursLeft -= hours;
        clockTime.UpdateTime(clockTime.Hours + hours, 0);
        clockTimeText.text = clockTime.ToString();
        if (hoursLeft <= 0)
            Calender.Instance.NextDay();
    }
}
