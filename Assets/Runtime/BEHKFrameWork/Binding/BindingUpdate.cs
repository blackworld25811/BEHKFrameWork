using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using static UnityEngine.PlayerLoop.PreUpdate;

namespace BEHKFrameWork.Binding
{
    public class BindingUpdate : MonoBehaviour
    {
        private static BindingUpdate instance;

        /// <summary>
        /// 
        /// </summary>
        internal static BindingUpdate Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = (BindingUpdate)FindObjectOfType(typeof(BindingUpdate));
                if (instance != null) return instance;
                var obj = new GameObject
                {
                    hideFlags = HideFlags.HideAndDontSave,
                    name = "BindingUpdate"
                };
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<BindingUpdate>();
                instance.Init();
                return instance;
            }
        }

        private Dictionary<BindingComponentValue<string>, BindingAttribute> bindingStringDictionary;

        private Dictionary<BindingAttribute, BindingComponentValue<int>> bindingIntDictionary;

        private Dictionary<BindingAttribute, BindingComponentValue<float>> bindingFloatDictionary;

        private float repeatRate;

        /// <summary>
        /// 
        /// </summary>
        public Dictionary<BindingComponentValue<string>, BindingAttribute> BindingStringDictionary
        { get => bindingStringDictionary; set => bindingStringDictionary = value; }

        public Dictionary<BindingAttribute, BindingComponentValue<int>> BindingIntDictionary
        { get => bindingIntDictionary; set => bindingIntDictionary = value; }

        public Dictionary<BindingAttribute, BindingComponentValue<float>> BindingFloatDictionary
        { get => bindingFloatDictionary; set => bindingFloatDictionary = value; }

        /// <summary>
        /// 
        /// </summary>
        private void Init()
        {
            if (Application.targetFrameRate == -1)
            {
                repeatRate = 1f / 120;
            }
            else
            {
                repeatRate = 1f / Application.targetFrameRate;
            }

            BindingStringDictionary = new Dictionary<BindingComponentValue<string>, BindingAttribute>();
            BindingIntDictionary = new Dictionary<BindingAttribute, BindingComponentValue<int>>();
            BindingFloatDictionary = new Dictionary<BindingAttribute, BindingComponentValue<float>>();

            InvokeRepeating("UpdateStringDictionary", 0, repeatRate);
            InvokeRepeating("UpdateIntDictionary", 0, repeatRate);
            InvokeRepeating("UpdateFloatDictionary", 0, repeatRate);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateStringDictionary()
        {
            foreach (var bindingString in bindingStringDictionary)
            {
                BindingComponentValue<string> key = bindingString.Key as BindingComponentValue<string>;
                BindingAttribute value = bindingString.Value as BindingAttribute;
         
                if (value.PropertyInfo != null)
                {
                    string oldValue = (string)value.OldPropertyValue;
                    string newValue = (string)value.PropertyInfo.GetValue(value.Object);

                    if (oldValue == null && newValue == null)
                    {
                        continue;
                    }
                    if (oldValue == null)
                    {
                        oldValue = newValue;
                        key.Value = newValue;
                        continue;
                    }
                    if (oldValue.Equals(newValue) == false)
                    {
                        oldValue = newValue;
                        key.Value = newValue;
                    }
                }
                if (value.FieldInfo != null)
                {
                    string oldValue = (string)value.OldFieldValue;
                    string newValue = (string)value.FieldInfo.GetValue(value.Object);
                    if (oldValue == null && newValue == null)
                    {
                        continue;
                    }
                    if (oldValue == null)
                    {
                        oldValue = newValue;
                        key.Value = newValue;
                        continue;
                    }
                    if (oldValue.Equals(newValue) == false)
                    {
                        oldValue = newValue;
                        key.Value = newValue;
                    }
                }
            }
        }

        private void UpdateIntDictionary()
        {

        }

        private void UpdateFloatDictionary()
        {

        }
    }
}
