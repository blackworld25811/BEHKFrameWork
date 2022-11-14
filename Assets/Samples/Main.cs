using BEHKFrameWork.Message;
using BEHKFrameWork.Binding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 30;
        MessageManager.Instance.RegisterListener(nameof(SampleReceiver), new SampleReceiver(), new SampleData());
        MessageManager.Instance.RegisterListener(nameof(OtherReceiver), new OtherReceiver(), new OtherData());
      
        Invoke("Delay",1); 
    }

    public void Delay()
    {
        MessageManager.Instance.SendMessage(Contants.Sample.Init);
    }
}
