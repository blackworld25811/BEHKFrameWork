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
        MessageManager.Instance.BindingMessage(nameof(data.Name), new Message(Contants.Other.ChangeData, null, data));
        MessageManager.Instance.BindingMessage(nameof(data.Id), new Message(Contants.Other.ChangeData, null, data));
        data.Button = Button_0;
       
    }

    private void Open()
    {
        data.Name = "456";
        data.Id = "change";
    }

    private void Close()
    {

    }

    private void Button_0()
    {
        Debug.Log("Button_0");
    }

    #endregion
}
