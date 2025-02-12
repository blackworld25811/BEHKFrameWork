using BEHKFrameWork.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class OtherReceiver : IListener
{
    private OtherData data;

    public string[] ListMessageInterests()
    {
        List<string> array = new List<string>
        {
            Other.ChangeData,
            Other.ChangeDataSecond,
            Sample.Test
        };
        return array.ToArray();
    }

    public void HandleMessageAsync(Message message)
    {
        switch (message.Name)
        {
            case Other.ChangeData:
                ChangeData(message);
                break;
            case Other.ChangeDataSecond:
                ChangeDataSecond();
                break;
            case Sample.Test:
                Test();
                break;
        }
    }

    private void ChangeData(Message message)
    {
        OtherData data = MessageManager.Instance.GetListenerData(nameof(OtherReceiver)) as OtherData;
        //SampleData data = message.Body as SampleData;
        //data.Name = "456";
        // Debug.Log("ChangeData");
    }

    private void ChangeDataSecond()
    {
        Debug.Log("ChangeDataSecond");
    }

    private void Test()
    {
        Debug.Log("Test_other");
    }
}
