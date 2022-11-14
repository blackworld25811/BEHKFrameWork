using BEHKFrameWork.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.Binding
{
    internal class BindingMessage: Singleton<BindingMessage>
    {

        private Action onMessage;

        public Action OnMessage { get => onMessage; set => onMessage = value; }

        public void Binding()
        {

        }
    }
}
