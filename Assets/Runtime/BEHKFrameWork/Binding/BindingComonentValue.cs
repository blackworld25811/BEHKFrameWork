using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.Binding
{
    public class BindingComponentValue<T>
    {
        private T value;

        private Action<T> onValueChanged;

        /// <summary>
        /// 
        /// </summary>
        public T Value
        {
            get { return value; }
            set
            {
                this.value = value;
                OnValueChanged(value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Action<T> OnValueChanged { get => onValueChanged; set => onValueChanged = value; }

        public BindingComponentValue(T t)
        {
            value = t;
        }
    }
}
