using BEHKFrameWork.Binding;
using BEHKFrameWork.Message;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleData : IData
{
    private string name;

    [Binding("Text_0")]
    public string Name { get => name; set => name = value; }

}
