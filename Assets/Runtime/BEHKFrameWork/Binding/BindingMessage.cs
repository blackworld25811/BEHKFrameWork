using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.Binding
{
    internal class BindingMessage
    {


        private Action onMessage;

        public Action OnMessage { get => onMessage; set => onMessage = value; }


    }
}
