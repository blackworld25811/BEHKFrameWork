using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace BEHKFrameWork.Binding
{
    public class TextBinding : MonoBehaviour
    {
        public string Key;

        public Text Text;

        private void OnEnable()
        {
            PropertyInfo property = BindingListenerData.Instance.GetProperty(Key);
            FieldInfo field = BindingListenerData.Instance.GetField(Key);

            if (property != null)
            {

            }
            if (field != null)
            {

            }
        }

    }

    public class UpdateTextBinding
    {

    }
}
