using BEHKFrameWork.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherReceiver : Listener
{
    private OtherData data;

    public override string[] ListMessageInterests()
    {
        List<string> array = new List<string>
        {
            Contants.Other.ChangeData,
            Contants.Other.ChangeDataSecond
        };
        return array.ToArray();
    }

    public override void HandleMessage(Message message)
    {
        switch (message.Name)
        {
            case Contants.Other.ChangeData:
                ChangeData(message);
                break;
            case Contants.Other.ChangeDataSecond:
                ChangeDataSecond();
                break;
        }
    }

    private void ChangeData(Message message)
    {
        SampleData data = message.Body as SampleData;
        data.Name = "456";
        Debug.Log("ChangeData");
    }

    private void ChangeDataSecond()
    {
        Debug.Log("ChangeDataSecond");
    }
}
