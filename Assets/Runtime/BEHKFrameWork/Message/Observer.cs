using System;

namespace BEHKFrameWork.Message
{
    internal class Observer
    {

        private Action<Message> listenerHandleMessage;

        private string listenerName;


        /// <summary>
        /// 
        /// </summary>
        public string ListenerName { get => listenerName; set => listenerName = value; }

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
