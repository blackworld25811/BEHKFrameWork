using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using BEHKFrameWork.Utility;

public class ComponentsBinding : MonoBehaviour
{
    [Tooltip("key is uniqueness,if key is null,use this gameobject name")]
    public string Key;

    public string GetKey()
    {
        Key =  Utility.RemoveStringBlank(Key);
        return Key.Equals("") ? name : Key;
    }
}