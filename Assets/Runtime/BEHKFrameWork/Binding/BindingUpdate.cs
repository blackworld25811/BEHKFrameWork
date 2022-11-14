using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


namespace BEHKFrameWork.Binding
{
    internal class BindingUpdate : MonoBehaviour
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

        private List<BindingAttribute> bindingAttributes;

        private float repeatRate;

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
            bindingAttributes = new List<BindingAttribute>();
            InvokeRepeating("UpdateBindingAttributes", 0, repeatRate);
        }

        internal void AddBindingAttributes(BindingAttribute bindingAttribute)
        {
            if (bindingAttributes.Contains(bindingAttribute) == false)
            {
                bindingAttributes.Add(bindingAttribute);
            }
        }

        private void UpdateBindingAttributes()
        {
            foreach (var bindingAttribute in bindingAttributes)
            {
                // check UI binding              
                if (bindingAttribute.PropertyInfo != null)
                {
                    object oldValue = bindingAttribute.OldPropertyValue;
                    object newValue = bindingAttribute.PropertyInfo.GetValue(bindingAttribute.Object);
                    if (oldValue == null && newValue == null)
                    {
                        continue;
                    }
                    if (oldValue == null || oldValue.Equals(newValue) == false)
                    {
                        bindingAttribute.OldPropertyValue = newValue;
                        foreach (var BindingComponentValue in bindingAttribute.BindingComponentValueList)
                        {
                            BindingComponentValue.Value = newValue;
                        }
                    }

                    if (bindingAttribute.FieldInfo != null)
                    {

                    }
                }



            }
        }
    }
}
