using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : Singleton<ObstacleHandler>
{
    public List<ObstacleEventSO> eventSOs;

    public void ThrowEvent()
    {
        int rand = Random.Range(0, 100);
        if (rand % 5 == 0) 
        {
            int randInt = Random.Range(0, eventSOs.Count - 1);
            Computer.Instance.NewNotification(eventSOs[randInt]);
        }
    }



}
