using System;
using System.Collections.Generic;
using System.Reflection;

namespace BEHKFrameWork.Binding
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class BindingAttribute : Attribute
    {
        private string key;

        private object @object;

        private PropertyInfo propertyInfo;

        private FieldInfo fieldInfo;

        private object oldPropertyValue;

        private object oldFieldValue;

        private List<BindingComponentValue<object>> bindingComponentValueList;

        private bool isMessage;

        private List<BindingMessage> bindingMessageList;

        /// <summary>
        /// 
        /// </summary>
        public string Key { get => key; set => key = value; }

        /// <summary>
        /// 
        /// </summary>
        public object Object { get => @object; set => @object = value; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyInfo PropertyInfo { get => propertyInfo; set => propertyInfo = value; }

        /// <summary>
        /// 
        /// </summary>
        public FieldInfo FieldInfo { get => fieldInfo; set => fieldInfo = value; }

        /// <summary>
        /// 
        /// </summary>
        public object OldPropertyValue { get => oldPropertyValue; set => oldPropertyValue = value; }

        /// <summary>
        ///  
        /// </summary>
        public object OldFieldValue { get => oldFieldValue; set => oldFieldValue = value; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsMessage { get => isMessage; set => isMessage = value; }

        /// <summary>
        /// 
        /// </summary>
        internal List<BindingComponentValue<object>> BindingComponentValueList { get => bindingComponentValueList; set => bindingComponentValueList = value; }
        internal List<BindingMessage> BindingMessageList { get => bindingMessageList; set => bindingMessageList = value; }

        public BindingAttribute(string key, bool isMessage = false)
        {
            if (BindingComponentValueList == null)
            {
                BindingComponentValueList = new List<BindingComponentValue<object>>();
            }
            if (BindingMessageList == null)
            {
                BindingMessageList = new List<BindingMessage>();
            }
            Key = key;
            IsMessage = isMessage;
        }

        public BindingAttribute(bool isMessage)
        {
            IsMessage = isMessage;
        }
    }
}
