using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace BEHKFrameWork.Binding.Component
{
    public class TMP_InputFieldBinding : ComponentsBinding
    {
        private TMP_InputField InputField;

        private Action<string> Action;

        void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            InputField = GetComponent<TMP_InputField>();
            if (bindingAttribute.PropertyInfo != null)
            {
                Action = bindingAttribute.PropertyInfo.GetValue(bindingAttribute.Object) as Action<string>;
            }
            if (bindingAttribute.FieldInfo != null)
            {
                Action = bindingAttribute.FieldInfo.GetValue(bindingAttribute.Object) as Action<string>;
            }
            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Action)
            {
                OnValueChanged = ChangeAddListener
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeAddListener(object action)
        {
            Action = action as Action<string>;
            InputField.onValueChanged.RemoveAllListeners();
            InputField.onValueChanged.AddListener(onValueChanged);
        }

        private void onValueChanged(string input)
        {
            Action(input);
        }
    }
}
