using System;

namespace BEHKFrameWork.Message
{
    internal class Observer
    {

        private Action<Message> listenerHandleMessage;

        private string listenerName;

        /// <summary>
        /// one listener has one ovserver,this is listener name
        /// </summary>
        public string ListenerName { get => listenerName; set => listenerName = value; }

        /// <summary>
        /// create a new observer
        /// </summary>
        /// <param name="listenerName"></param>
        /// <param name="listenerHandleMessage"></param>
        public Observer(string listenerName, Action<Message> listenerHandleMessage)
        {
            this.listenerName = listenerName;
            this.listenerHandleMessage = listenerHandleMessage;
        }

        /// <summary>
        /// Execute the logic for the message
        /// </summary>
        /// <param name="message"></param>
        public void Execute(Message message)
        {
            listenerHandleMessage(message);
        }
    }
}
