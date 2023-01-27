using System;

namespace BEHKFrameWork.Binding
{
    internal class BindingMessage
    {
        private Action<Message.Message> onMessage;

        private Message.Message message;

        /// <summary>
        /// send message logic
        /// </summary>
        public Action<Message.Message> OnMessage { get => onMessage; set => onMessage = value; }

        /// <summary>
        /// the specific message 
        /// </summary>
        public Message.Message Message { get => message; set => message = value; }

        /// <summary>
        /// excute the logic of message 
        /// </summary>
        /// <param name="message"></param>
        public void Execute(Message.Message message)
        {
            onMessage(message);
        }
    }
}
