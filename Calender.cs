using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calender : Singleton<Calender>
{

    int daysLeft = 7;

    public TextMeshProUGUI daysLeftText;
    public float timeToWait = 2f;
    public GameObject NextDayPanel;
    public GameObject winPanel;
    public GameObject losePanel;


    void Start()
    {
        daysLeft = 7;
        Clock.Instance.ResetTime();
    }

    public void NextDay()
    {
        daysLeft--;
        Clock.Instance.ResetTime();
        StartCoroutine(showNDPanel());
        if (Points.Instance.HasWon()) { winPanel.SetActive(true); } //win
        if (daysLeft <= 0) { losePanel.SetActive(true); } //lose
        
        
    }

    IEnumerator showNDPanel()
    {
        daysLeftText.text = "Days left: " + daysLeft;
        NextDayPanel.SetActive(true);
        yield return new WaitForSeconds(timeToWait);
        NextDayPanel.SetActive(false);
        StopAllCoroutines();
    }

}
