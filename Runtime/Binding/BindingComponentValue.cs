using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.Binding
{
    internal class BindingComponentValue<T>
    {
        private T value;

        private Action<T> onValueChanged;

        /// <summary>
        /// the ui change value
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
        /// the ui change logic
        /// </summary>
        public Action<T> OnValueChanged
        {
            get => onValueChanged;
            set => onValueChanged = value;
        }

        public BindingComponentValue(T t)
        {
            value = t;
        }
    }
}