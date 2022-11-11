using System;

namespace BEHKFrameWork.Message
{
    public class Observer
    {

        private Action<Message> listenerHandleMessage;

        private object listener;

        /// <summary>
        /// transfer listener HandleMessage 
        /// </summary>
        public Action<Message> ListenerHandleMessage { get => listenerHandleMessage; set => listenerHandleMessage = value; }

        /// <summary>
        /// 
        /// </summary>
        public object Listener { get => listener; set => listener = value; }

        public Observer(Action<Message> listenerHandleMessage, object listener)
        {
            ListenerHandleMessage = listenerHandleMessage;
            Listener = listener;
        }

        /// <summary>
        /// Execute the logic for the message
        /// </summary>
        /// <param name="message"></param>
        public void Execute(Message message)
        {
            ListenerHandleMessage(message);
        }
    }
}
