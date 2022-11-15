using System;

namespace BEHKFrameWork.Binding
{
    internal class BindingMessage
    {

        private Action<Message.Message> onMessage;

        private Message.Message message;

        /// <summary>
        /// 
        /// </summary>
        public Action<Message.Message> OnMessage { get => onMessage; set => onMessage = value; }

        /// <summary>
        /// 
        /// </summary>
        public Message.Message Message { get => message; set => message = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public void Execute(Message.Message message)
        {
            onMessage(message);
        }
    }
}
