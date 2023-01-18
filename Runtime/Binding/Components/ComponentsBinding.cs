using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ComponentsBinding : MonoBehaviour
{
    [Tooltip("key is uniqueness,if key is null,use this gameobject name")]
    public string Key;

    public string GetKey()
    {
        // remove all of blank
        Key = Regex.Replace(Key, @"\s", "");
        return Key.Equals("") ? name : Key;
    }
}