using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class TestDataFather
{
    public TestDataFather()
    {
        Type type = GetType();
        PropertyInfo[] propertyInfos = type.GetProperties();
        FieldInfo[] fieldInfos = type.GetFields();
        Debug.Log("1111");
    }
}
