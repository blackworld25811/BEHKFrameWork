using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateValue<T>
{
    private T changeValue { get; set; }

    public Action<T> OnValueChanged { get; set; }

    public UpdateValue(T value)
    {
        changeValue = value;
    }

    public T Value
    {
        get { return changeValue; }
        set { }
    }



    public virtual void Update()
    {

    }
}
