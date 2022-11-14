using BEHKFrameWork.Binding;
using BEHKFrameWork.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleData : IData
{
    private string name;

    private string id;

    [Binding("Text_0", true)]
    public string Name { get => name; set => name = value; }
    //[Binding(true)]
    public string Id { get => id; set => id = value; }
}
