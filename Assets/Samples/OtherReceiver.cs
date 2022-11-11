using BEHKFrameWork.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherReceiver : IListener
{
    private OtherData data;

    public string[] ListMessageInterests()
    {
        List<string> array = new List<string>
        {
            Contants.Other.ChangeData,
        };
        return array.ToArray();
    }

    public void HandleMessage(Message message)
    {
        switch (message.Name)
        {
            case Contants.Other.ChangeData:
                ChangeData(message);
                break;
        }
    }

    private void ChangeData(Message message)
    {
        SampleData data = message.Body as SampleData;
        data.Name = "456";
        Debug.Log("name  = " + data.Name);
    }


}
