﻿using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameActionHandler : MonoBehaviour
{
    public GameAction action;
    public UnityEvent startEvent, Event, LateEvent;
    public float holdTime = 0.1f;
    private WaitForSeconds waitObj;

    private void Start()
    {
        startEvent.Invoke();
    }

    private void OnEnable()
    {
        waitObj = new WaitForSeconds(holdTime);
        action.raiseNoArgs += Respond;
    }

    private void Respond()
    {
        Event.Invoke();
        StartCoroutine(RespondLate());
    }

    private IEnumerator RespondLate()
    {
        yield return waitObj;
        LateEvent.Invoke();
    }
}