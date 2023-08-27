using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIEvents : MonoBehaviour
{
    public static UIEvents Instance;

    public event Action StartAcelerateEvent = delegate { };
    public event Action StopAcelerateEvent = delegate { };
    public delegate void TurnDelegate(int dir);
    public event TurnDelegate TurnEvent = delegate { };

    private void Awake()
    {
        Instance = this;
    }

    public void StartAceleration()
    {
        StartAcelerateEvent();
    }

    public void FinishAceleration()
    {
        StopAcelerateEvent();
    }

    public void Turn(int direction)
    {
        TurnEvent(direction);
    }
}
