using System;
using BEHKFrameWork.Message;
using BEHKFrameWork.Binding;
using UnityEngine;

public class SampleData : IData
{
    private string name;

    private string id;

    private Action button;

    [Binding("Text_0")]
    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Id
    {
        get => id;
        set => id = value;
    }

    [Binding("Button_0")]
    public Action Button
    {
        get => button;
        set => button = value;
    }
}