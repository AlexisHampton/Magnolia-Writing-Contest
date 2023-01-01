using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleChoiceEvent : Singleton<HandleChoiceEvent>
{
    private void Awake()
    {
        DialogueManager.OnChoice += PickChoice;
    }

    private void OnDestroy()
    {
        DialogueManager.OnChoice -= PickChoice;
    }

    public void PickChoice(int activity)
    {

        switch(activity)
        {
            case 1:
                Clock.Instance.PassTime(2);
                break;
            case 2:
                Calender.Instance.NextDay();
                break;
            case 3:
                Computer.Instance.TurnOn();
                Computer.Instance.WriteMore();
                break;
        }

    }

}
