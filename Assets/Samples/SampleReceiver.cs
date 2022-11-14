using BEHKFrameWork.Message;
using System.Collections.Generic;
using UnityEngine;

public class SampleReceiver : IListener
{
    private SampleData data;

    #region logic register
    public string[] ListMessageInterests()
    {
        List<string> array = new List<string>
        {
            Contants.Sample.Init,
            Contants.Sample.Open,
            Contants.Sample.Close,
        };
        return array.ToArray();
    }

    public void HandleMessage(Message message)
    {
        switch (message.Name)
        {
            case Contants.Sample.Init:
                Init();
                break;
            case Contants.Sample.Open:
                Open();
                break;
            case Contants.Sample.Close:
                Close();
                break;
        }
    }
    #endregion


    #region logic
    private void Init()
    {
        data = MessageManager.Instance.GetListenerData(nameof(SampleReceiver)) as SampleData;
        data.Name = "123";

       // MessageManager.Instance.BindingMessage(data.Name, Contants.Other.ChangeData);
      // MessageManager.Instance.BindingMessage(data.Name, Contants.Other.ChangeDataSecond);
    }

    private void Open()
    {
        data.Name = "456";
    }

    private void Close()
    {

    }
    #endregion
}
