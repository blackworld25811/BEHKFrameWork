using UnityEngine;

namespace BEHKFrameWork.Binding.Component
{
    public class LocalScaleBinding : ComponentsBinding
    {
        private void Start()
        {
            BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(GetKey());
            if (bindingAttribute == null) return;

            BindingComponentValue<object> bindingComponentValue = new BindingComponentValue<object>(transform)
            {
                OnValueChanged = ChangeActive
            };
            bindingAttribute.BindingComponentValueList.Add(bindingComponentValue);
        }

        private void ChangeActive(object scale)
        {
            transform.localScale = (Vector3)scale;
        }
    }
}
