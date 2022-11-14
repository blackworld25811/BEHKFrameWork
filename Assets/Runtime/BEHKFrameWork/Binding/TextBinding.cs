using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Cryptography;
using BEHKFrameWork.Message;
using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding
{
    public class TextBinding : MonoBehaviour
    {
        public string Key;

        public Text Text;


        private void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(Key);

            if (bindingAttribute != null)
            {
                BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Text.text);
                bindingComponentValue.OnValueChanged = ChangeText;
                bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
                BindingUpdate.Instance.AddBindingAttributes(bindingAttribute);
            }
        }

        private void ChangeText(object text)
        {
            Text.text = (string)text;
        }
    }
}
