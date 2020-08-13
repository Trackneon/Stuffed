﻿using System;
using UnityEngine;
using UnityEngine.Events;

[ExecuteInEditMode, CreateAssetMenu(menuName = "Single Variables/FloatData")]
public class FloatData : NameId
{
    public float value;
    public UnityEvent minValueEvent, maxValueEvent, updateValueEvent;
    
    public void SetValue (float amount)
    {
        value = amount;
    }

    public void UpdateValue(float amount)
    {
        value += amount;
        updateValueEvent.Invoke();
    }

    public void IncrementValue()
    {
        value ++;
    }
    
    public void UpdateValue(FloatData data)
    {
        var newData = data as FloatData;
        if (newData != null) value += newData.value;
    }

    public void SetValue(FloatData data)
    {
        var newData = data as FloatData;
        if (newData != null) value = newData.value;
    }
    
    public void CheckMinValue(float minValue)
    {
        if (!(value < minValue)) return;
        minValueEvent.Invoke();
        value = minValue;
    }

    public void CheckMaxValue(float maxValue)
    {
        if (!(value >= maxValue)) return;
        maxValueEvent.Invoke();
        value = maxValue;
    }
}