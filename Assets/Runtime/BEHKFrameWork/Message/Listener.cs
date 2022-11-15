using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BEHKFrameWork.Message
{
    public class Listener : IListener
    {
        public IData GetData(string name)
        {
           return MessageManager.Instance.GetListenerData(name);
        }

        public virtual void HandleMessage(Message message)
        {
            throw new System.NotImplementedException();
        }

        public virtual string[] ListMessageInterests()
        {
            throw new System.NotImplementedException();
        }
    }
}
