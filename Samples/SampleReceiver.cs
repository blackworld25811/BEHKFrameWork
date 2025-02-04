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
            Sample.Test
        };
        return array.ToArray();
    }

    public void HandleMessageAsync(Message message)
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
            case Sample.Test:
                Test();
                break;
        }
    }
    #endregion


    #region logic
    private void Init()
    {
        data = MessageManager.Instance.GetListenerData(nameof(SampleReceiver)) as SampleData;
        data.Text_0 = "123";
        MessageManager.Instance.BindingMessage(nameof(data.Text_0), new Message(Other.ChangeData, null, data));
        MessageManager.Instance.BindingMessage(nameof(data.Id), new Message(Other.ChangeData, null, data));
        data.Button = Button_0;
        data.Toggle = Toggle;
        data.Active = false;
        data.InputField = TMP_InputField;
        data.LocalPosition = new Vector3(5, 5, 5);
        data.LocalRotation = new Vector3(0, 0, 20);
        data.LocalScale = new Vector3(2, 2, 2);
        data.Scrollbar = Scrollbar;
    }

    private void Open()
    {
        data.Text_0 = "456";
        data.Id = "change";
        data.Active = true;
        data.Active_text_0 = true;
        MessageManager.Instance.SendMessage(Constants.Sample.Test);
    }

    private void Close()
    {

    }

    private void Test()
    {
        Debug.Log("Test_sample");
    }

    private void Button_0()
    {
        Debug.Log("Button_0");
    }

    private void Toggle(bool isOn)
    {
        Debug.Log(isOn);
    }

    private void Scrollbar(float value)
    {
        Debug.Log(value);
    }

    private void TMP_InputField(string input)
    {
        Debug.Log(input);
    }



    #endregion
}
