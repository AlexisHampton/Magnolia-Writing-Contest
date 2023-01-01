using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : Singleton<Points>
{

    int progress = 0;

    private void Start()
    {
        progress = 0;
    }

    public bool HasWon()
    {
        if (progress >= 80) { return true; }
        return false;
    }

    public void IncreaseProgress()
    {
        progress += 20;
    }

}
