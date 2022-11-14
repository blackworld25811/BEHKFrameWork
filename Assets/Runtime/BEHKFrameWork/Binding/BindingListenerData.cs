using System;
using System.Reflection;
using UnityEngine;
using BEHKFrameWork.Utility;
using BEHKFrameWork.Message;
using System.Collections.Generic;

namespace BEHKFrameWork.Binding
{
    internal class BindingListenerData : Singleton<BindingListenerData>
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<string, BindingAttribute> keyAttributeDictionary;

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<PropertyInfo, BindingAttribute> propertyInfoAttributeDictionary;

        /// <summary>
        /// 
        /// </summary>
        private readonly Dictionary<FieldInfo, BindingAttribute> fieldInfoAttributeDictionary;

        public BindingListenerData()
        {
            keyAttributeDictionary = new Dictionary<string, BindingAttribute>();
            propertyInfoAttributeDictionary = new Dictionary<PropertyInfo, BindingAttribute>();
            fieldInfoAttributeDictionary = new Dictionary<FieldInfo, BindingAttribute>();
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
                if (bindingAttribute == null)
                {
                    continue;
                }
                bindingAttribute.Object = data;
                bindingAttribute.PropertyInfo = propertyInfo;
                bindingAttribute.OldFieldValue = propertyInfo.GetValue(data);
                keyAttributeDictionary.Add(bindingAttribute.Key, bindingAttribute);
                propertyInfoAttributeDictionary.Add(propertyInfo, bindingAttribute);
            }
            // check all of field
            FieldInfo[] fieldInfos = type.GetFields();
            foreach (var fieldInfo in fieldInfos)
            {
                BindingAttribute bindingAttribute = fieldInfo.GetCustomAttribute<BindingAttribute>();
                if (bindingAttribute == null)
                {
                    continue;
                }
                bindingAttribute.Object = data;
                bindingAttribute.FieldInfo = fieldInfo;
                bindingAttribute.OldFieldValue = fieldInfo.GetValue(data);
                keyAttributeDictionary.Add(bindingAttribute.Key, bindingAttribute);
                fieldInfoAttributeDictionary.Add(fieldInfo, bindingAttribute);
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

        public BindingAttribute GetBindingAttribute(PropertyInfo propertyInfo)
        {
            if (propertyInfoAttributeDictionary.TryGetValue(propertyInfo, out BindingAttribute value))
            {
                return value;
            }
            return null;
        }

        public BindingAttribute GetBindingAttribute(FieldInfo fieldInfo)
        {
            if (fieldInfoAttributeDictionary.TryGetValue(fieldInfo, out BindingAttribute value))
            {
                return value;
            }
            return null;
        }
    }
}

