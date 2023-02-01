using BEHKFrameWork.Message;
using BEHKFrameWork.Binding;
using BEHKFrameWork.UIManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;

public class Main : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 30;
        MessageManager.Instance.RegisterListener(nameof(SampleReceiver), new SampleReceiver(), new SampleData());
        MessageManager.Instance.RegisterListener(nameof(OtherReceiver), new OtherReceiver(), new OtherData());

        Invoke("Delay_0", 1);
        Invoke("Delay_1", 2);

        UIManager.Instance.Initialize(Canvas.Instance);
        Debug.Log("");
    }

    public void Delay_0()
    {
        MessageManager.Instance.SendMessage(Constants.Sample.Init);
    }

    public void Delay_1()
    {
        MessageManager.Instance.SendMessage(Constants.Sample.Open);
    }

}
