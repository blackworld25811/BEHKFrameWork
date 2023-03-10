using System;
using BEHKFrameWork.Message;
using BEHKFrameWork.Binding;
using UnityEngine;

public class SampleData : IData
{
    private string text_0;

    private bool active_text_0;

    private string id;

    private bool active;

    private Action button;

    private Action<bool> toggle;

    private Action<string> inputField;

    private Action<float> scrollbar;

    private Vector3 localPosition;

    private Vector3 localRotation;

    private Vector3 localScale;

    [Binding("Text_0")]
    public string Text_0
    {
        get => text_0; set => text_0 = value;
    }

    [Binding("Text_0_active")]
    public bool Active_text_0 { get => active_text_0; set => active_text_0 = value; }

    public string Id
    {
        get => id; set => id = value;
    }

    [Binding("Image_active")]
    public bool Active { get => active; set => active = value; }

    [Binding("Button_0")]
    public Action Button
    {
        get => button; set => button = value;
    }

    [Binding("Toggle")]
    public Action<bool> Toggle { get => toggle; set => toggle = value; }

    [Binding("InputField (TMP)")]
    public Action<string> InputField { get => inputField; set => inputField = value; }

    [Binding("LocalPositionBinding_Image")]
    public Vector3 LocalPosition { get => localPosition; set => localPosition = value; }

    [Binding("LocalRotationBinding_Image")]
    public Vector3 LocalRotation { get => localRotation; set => localRotation = value; }

    [Binding("LocalScaleBinding_Image")]
    public Vector3 LocalScale { get => localScale; set => localScale = value; }

    [Binding("Scrollbar")]
    public Action<float> Scrollbar { get => scrollbar; set => scrollbar = value; }
}