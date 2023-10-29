using System;
using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding.Component
{
    public class ScrollRectBinding : ComponentsBinding
    {
        private ScrollRect ScrollRect;

        private Action<Vector2> Action;

        void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            ScrollRect = GetComponent<ScrollRect>();
            if (bindingAttribute.PropertyInfo != null)
            {
                Action = bindingAttribute.PropertyInfo.GetValue(bindingAttribute.Object) as Action<Vector2>;
            }
            if (bindingAttribute.FieldInfo != null)
            {
                Action = bindingAttribute.FieldInfo.GetValue(bindingAttribute.Object) as Action<Vector2>;
            }
            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(Action)
            {
                OnValueChanged = ChangeAddListener
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeAddListener(object action)
        {
            Action = action as Action<Vector2>;
            ScrollRect.onValueChanged.RemoveAllListeners();
            ScrollRect.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(Vector2 value)
        {
            Action?.Invoke(value);
        }
    }
}
