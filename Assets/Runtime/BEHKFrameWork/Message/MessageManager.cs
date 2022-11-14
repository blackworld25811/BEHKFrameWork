using System.Collections.Concurrent;
using System.Collections.Generic;
using BEHKFrameWork.Utility;
using BEHKFrameWork.Binding;
using System;

namespace BEHKFrameWork.Message
{
    public class MessageManager : Singleton<MessageManager>
    {
        /// <summary>
        /// all of observers,one observers can observe multiple message
        /// </summary>
        private readonly ConcurrentDictionary<string, Observer> observerDictionary;
        /// <summary>
        /// all of listeners,listener'every message must be have a observer
        /// </summary>
        private readonly ConcurrentDictionary<string, IListener> listenerDictionary;
        /// <summary>
        /// the listener private data
        /// </summary>
        private readonly ConcurrentDictionary<string, IData> dataDictionary;


        public MessageManager()
        {
            observerDictionary = new ConcurrentDictionary<string, Observer>();
            listenerDictionary = new ConcurrentDictionary<string, IListener>();
            dataDictionary = new ConcurrentDictionary<string, IData>();
        }

        /// <summary>
        /// register listener,used when you need to process whohle logic
        /// </summary>
        /// <param name="listenerName"></param>
        /// listener's name,is unique
        /// <param name="iListener"></param>
        /// <param name="iData"></param>
        public void RegisterListener(string listenerName, IListener iListener, IData iData)
        {
            if (listenerDictionary.TryAdd(listenerName, iListener))
            {
                dataDictionary.TryAdd(listenerName, iData);
                BindingListenerData.Instance.Binding(iData);

                var interests = iListener.ListMessageInterests();
                if (interests.Length > 0)
                {
                    Observer observer = new Observer(iListener.HandleMessage, iListener);
                    // regsiter every message
                    foreach (var interest in interests)
                    {
                        RegisterMessage(interest, observer);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listenerName"></param>
        /// <returns></returns>
        public IData GetListenerData(string listenerName)
        {
            if (dataDictionary.TryGetValue(listenerName, out var data))
            {
                return data;
            }
            return null;
        }

        /// <summary>
        /// register single observer
        /// </summary>
        /// <param name="messageName"></param>
        /// <param name="observer"></param>
        private void RegisterMessage(string messageName, Observer observer)
        {
            observerDictionary.TryAdd(messageName, observer);
        }

        /// <summary>
        /// send a message 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="body"></param>
        public void SendMessage(string name, string type = null, object body = null)
        {
            Message message = new Message(name, type, body);

            if (observerDictionary.TryGetValue(name, out var observer))
            {
                observer.Execute(message);
            }
        }

  
        public void BindingMessage(string messageName)
        {
            
        }
    }
}
