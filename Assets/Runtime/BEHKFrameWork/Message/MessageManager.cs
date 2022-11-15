using System.Collections.Concurrent;
using System.Collections.Generic;
using BEHKFrameWork.Utility;
using BEHKFrameWork.Binding;
using System;
using System.Reflection;

namespace BEHKFrameWork.Message
{
    public class MessageManager : Singleton<MessageManager>
    {
        /// <summary>
        /// all of observers,one observers can observe multiple message
        /// </summary>
        private readonly ConcurrentDictionary<string, Observer> observerDictionary;
        /// <summary>
        /// all of listeners,listener's every message must be have a observer
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
                    Observer observer = new Observer(listenerName, iListener.HandleMessage);
                    // regsiter every message
                    foreach (var interest in interests)
                    {
                        RegisterMessage(interest, observer);
                    }
                }
            }
        }

        /// <summary>
        /// get one listerner's private data
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

        public void SendMessage(string name, object body)
        {
            Message message = new Message(name, null, body);

            if (observerDictionary.TryGetValue(name, out var observer))
            {
                observer.Execute(message);
            }
        }

        public void SendMessage(Message message)
        {
            if (observerDictionary.TryGetValue(message.Name, out var observer))
            {
                observer.Execute(message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="message"></param>
        public void BindingMessage(string name, Message message)
        {
            // get listener name
            MethodBase method = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod();
            string className = method.ReflectedType.FullName;

            if (dataDictionary.TryGetValue(className, out var data))
            {
                Type type = data.GetType();
                PropertyInfo[] propertyInfos = type.GetProperties();
                FieldInfo[] fieldInfos = type.GetFields();
                foreach (var propertyInfo in propertyInfos)
                {
                    if (propertyInfo.Name.Equals(name))
                    {
                        BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(propertyInfo);
                        BindingMessage bindingMessage = new BindingMessage();
                        bindingMessage.Message = message;
                        bindingMessage.OnMessage = SendMessage;
                        bindingAttribute.BindingMessageList.Add(bindingMessage);
                        break;
                    }
                }
                foreach (var fieldInfo in fieldInfos)
                {
                    if (fieldInfo.Name.Equals(name))
                    {
                        BindingAttribute bindingAttribute = BindingListenerData.Instance.GetBindingAttribute(fieldInfo);
                        BindingMessage bindingMessage = new BindingMessage();
                        bindingMessage.Message = message;
                        bindingMessage.OnMessage = SendMessage;
                        bindingAttribute.BindingMessageList.Add(bindingMessage);
                        break;
                    }
                }
            }
        }
    }
}
