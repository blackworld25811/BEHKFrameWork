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

        private List<BindingMessage> bindingMessageList;

        /// <summary>
        /// custom UI key
        /// </summary>
        public string Key
        {
            get => key; set => key = value;
        }

        /// <summary>
        /// the class of property or field
        /// </summary>
        public object Object
        {
            get => @object; set => @object = value;
        }

        /// <summary>
        /// reflection property
        /// </summary>
        public PropertyInfo PropertyInfo
        {
            get => propertyInfo; set => propertyInfo = value;
        }

        /// <summary>
        /// reflection field
        /// </summary>
        public FieldInfo FieldInfo
        {
            get => fieldInfo; set => fieldInfo = value;
        }

        /// <summary>
        ///  record the property old value,compare to new value
        /// </summary>
        public object OldPropertyValue
        {
            get => oldPropertyValue;
            set => oldPropertyValue = value;
        }

        /// <summary>
        ///  record the field old value,compare to new value
        /// </summary>
        public object OldFieldValue
        {
            get => oldFieldValue; set => oldFieldValue = value;
        }

        /// <summary>
        /// UI componet binding information
        /// </summary>
        internal List<BindingComponentValue<object>> BindingComponentValueList
        {
            get => bindingComponentValueList; set => bindingComponentValueList = value;
        }

        /// <summary>
        /// logic message binding information
        /// </summary>
        internal List<BindingMessage> BindingMessageList
        {
            get => bindingMessageList; set => bindingMessageList = value;
        }

        /// <summary>
        /// create bindingAttribute, uesed the UI component key
        /// </summary>
        /// <param name="key"></param>
        public BindingAttribute(string key)
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
        }
    }
}