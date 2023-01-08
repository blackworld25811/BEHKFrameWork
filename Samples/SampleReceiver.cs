using BEHKFrameWork.Message;
using System.Collections.Generic;
using UnityEngine;
using static Constants;  

public class SampleReceiver : IListener
{
    private SampleData data;

    #region logic register
    public string[] ListMessageInterests()
    {
        List<string> array = new List<string>
        {
            Sample.Init,
            Sample.Open,
            Sample.Close,
        };
        return array.ToArray();
    }

    public void HandleMessage(Message message)
    {
        switch (message.Name)
        {
            case Sample.Init:
                Init();
                break;
            case Sample.Open:
                Open();
                break;
            case Sample.Close:
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
        MessageManager.Instance.BindingMessage(nameof(data.Name), new Message(Other.ChangeData, null, data));
        MessageManager.Instance.BindingMessage(nameof(data.Id), new Message(Other.ChangeData, null, data));
        data.Button = Button_0;
        data.Active = false;
    }

    private void Open()
    {
        data.Name = "456";
        data.Id = "change";
        data.Active = true;
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
