using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.Binding
{
    internal class BindingUpdate : MonoBehaviour
    {
        private static BindingUpdate instance;

        /// <summary>
        /// all of bindingAttribute to be refresh
        /// </summary>
        private List<BindingAttribute> bindingAttributes;

        /// <summary>
        /// refresh frame time
        /// </summary>
        private float repeatRate;

        /// <summary>
        /// the monobehaviour instance,is run in background
        /// </summary>
        internal static BindingUpdate Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = (BindingUpdate)FindFirstObjectByType(typeof(BindingUpdate));
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

        private void OnDestroy()
        {
            CancelInvoke();
        }

        /// <summary>
        /// initialize
        /// </summary>
        private void Init()
        {
            int frame = -1;
            if (PlayerPrefs.HasKey("Frame"))
            {
                frame = PlayerPrefs.GetInt("Frame");
            }
            if (frame == -1)
            {
                // the max frame time
                repeatRate = 1f / 120;
            }
            else
            {
                Application.targetFrameRate = frame;
                repeatRate = 1f / frame;
            }
            bindingAttributes = new List<BindingAttribute>();
            InvokeRepeating(nameof(UpdateBindingAttributes), 0, repeatRate);
        }

        /// <summary>
        /// add a bindingAttribute,ui and message logic all need
        /// </summary>
        /// <param name="bindingAttribute"></param>
        internal void AddBindingAttributes(BindingAttribute bindingAttribute)
        {
            if (bindingAttributes.Contains(bindingAttribute) == false)
            {
                bindingAttributes.Add(bindingAttribute);
            }
        }

        /// <summary>
        /// refresh all porerty or field change and excute they logic
        /// </summary>
        private void UpdateBindingAttributes()
        {
            foreach (var bindingAttribute in bindingAttributes)
            {
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
                        // refresh all binding component
                        foreach (var BindingComponentValue in bindingAttribute.BindingComponentValueList)
                        {
                            BindingComponentValue.Value = newValue;
                        }
                        // send all binding message
                        foreach (var bindingMessage in bindingAttribute.BindingMessageList)
                        {
                            bindingMessage.Execute(bindingMessage.Message);
                        }
                    }
                }

                if (bindingAttribute.FieldInfo != null)
                {
                    object oldValue = bindingAttribute.OldFieldValue;
                    object newValue = bindingAttribute.FieldInfo.GetValue(bindingAttribute.Object);
                    if (oldValue == null && newValue == null)
                    {
                        continue;
                    }
                    if (oldValue == null || oldValue.Equals(newValue) == false)
                    {
                        bindingAttribute.OldFieldValue = newValue;
                        // refresh all binding component
                        foreach (var BindingComponentValue in bindingAttribute.BindingComponentValueList)
                        {
                            BindingComponentValue.Value = newValue;
                        }
                        // send all binding message
                        foreach (var bindingMessage in bindingAttribute.BindingMessageList)
                        {
                            bindingMessage.Execute(bindingMessage.Message);
                        }
                    }
                }
            }
        }
    }
}
