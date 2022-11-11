using System;
using System.Reflection;
using UnityEngine;
using BEHKFrameWork.Utility;
using BEHKFrameWork.Message;
using System.Collections.Generic;

namespace BEHKFrameWork.Binding
{
    public class BindingListenerData : Singleton<BindingListenerData>
    {
        private readonly Dictionary<string, PropertyInfo> keyPropertyDictionary;

        private readonly Dictionary<string, FieldInfo> keyFieldDictionary;

        public BindingListenerData()
        {
            keyPropertyDictionary = new Dictionary<string, PropertyInfo>();
            keyFieldDictionary = new Dictionary<string, FieldInfo>();
        }

        public void Binding(IData data)
        {
            Type type = data.GetType();
            // check all of property
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                BindingAttribute bindingAttribute = propertyInfo.GetCustomAttribute<BindingAttribute>();
                keyPropertyDictionary.Add(bindingAttribute.Key, propertyInfo);
            }
            // check all of field
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                BindingAttribute bindingAttribute = fieldInfo.GetCustomAttribute<BindingAttribute>();
                keyFieldDictionary.Add(bindingAttribute.Key, fieldInfo);
            }
        }

        public PropertyInfo GetProperty(string key)
        {
            return keyPropertyDictionary[key];
        }

        public FieldInfo GetField(string key)
        {
            return keyFieldDictionary[key];
        }
    }
}

