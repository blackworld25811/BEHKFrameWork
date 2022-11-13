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
                BindingComponentValue<string> bindingComponentValue = new BindingComponentValue<string>(Text.text);
                bindingComponentValue.OnValueChanged = ChangeText;
                BindingUpdate.Instance.BindingStringDictionary.Add(bindingComponentValue,bindingAttribute);
            }

        }

        private void ChangeText(string text)
        {
            Text.text = text;
        }
    }
}
