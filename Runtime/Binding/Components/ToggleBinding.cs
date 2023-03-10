using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding.Component
{
    public class ToggleBinding : ComponentsBinding
    {
        private Toggle Toggle;

        private Action<bool> Action;

        void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            Toggle = GetComponent<Toggle>();
            if (bindingAttribute.PropertyInfo != null)
            {
                Action = bindingAttribute.PropertyInfo.GetValue(bindingAttribute.Object) as Action<bool>;
            }
            if (bindingAttribute.FieldInfo != null)
            {
                Action = bindingAttribute.FieldInfo.GetValue(bindingAttribute.Object) as Action<bool>;
            }
            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Action)
            {
                OnValueChanged = ChangeAddListener
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeAddListener(object action)
        {
            Action = action as Action<bool>;
            Toggle.onValueChanged.RemoveAllListeners();
            Toggle.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(bool isOn)
        {
            Action?.Invoke(isOn);
        }
    }
}
