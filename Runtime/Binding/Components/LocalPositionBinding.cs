using UnityEngine;

namespace BEHKFrameWork.Binding.Component
{
    public class LocalPositionBinding : ComponentsBinding
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

        private void ChangeActive(object position)
        {
            transform.localPosition = (Vector3)position;
        }
    }
}
