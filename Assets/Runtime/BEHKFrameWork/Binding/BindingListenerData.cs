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
        private readonly Dictionary<string, BindingAttribute> keyAttributeDictionary;

        public BindingListenerData()
        {
            keyAttributeDictionary = new Dictionary<string, BindingAttribute>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void Binding(IData data)
        {
            Type type = data.GetType();
            // check all of property
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                BindingAttribute bindingAttribute = propertyInfo.GetCustomAttribute<BindingAttribute>();
                bindingAttribute.Object = data;
                bindingAttribute.PropertyInfo = propertyInfo;
                bindingAttribute.OldFieldValue = propertyInfo.GetValue(data);
                keyAttributeDictionary.Add(bindingAttribute.Key, bindingAttribute);
            }
            // check all of field
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                BindingAttribute bindingAttribute = fieldInfo.GetCustomAttribute<BindingAttribute>();
                bindingAttribute.Object = data;
                bindingAttribute.FieldInfo = fieldInfo;
                bindingAttribute.OldFieldValue = fieldInfo.GetValue(data);
                keyAttributeDictionary.Add(bindingAttribute.Key, bindingAttribute);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public BindingAttribute GetBindingAttribute(string key)
        {
            if (keyAttributeDictionary.TryGetValue(key, out BindingAttribute value))
            {
                return value;
            }
            return null;
        }
    }
}

