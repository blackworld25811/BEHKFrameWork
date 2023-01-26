using System;
using BEHKFrameWork.Message;
using BEHKFrameWork.Binding;
using UnityEngine;

public class SampleData : IData
{
    private string name;

    private string id;

    private bool active;

    private bool active_text;

    private Action button;

    private Action<bool> toggle;

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

    [Binding("Text_0_active")]
    public bool Active_text { get => active_text; set => active_text = value; }

    [Binding("Image_active")]
    public bool Active { get => active; set => active = value; }

    [Binding("Button_0")]
    public Action Button
    {
        get => button;
        set => button = value;
    }

    [Binding("Toggle")]
    public Action<bool> Toggle { get => toggle; set => toggle = value; }
}