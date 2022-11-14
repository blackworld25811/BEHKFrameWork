using System;

namespace BEHKFrameWork.Binding
{
    internal class BindingMessage
    {

        private Action<Message.Message> onMessage;

        private Message.Message message;

        public Action<Message.Message> OnMessage { get => onMessage; set => onMessage = value; }

        public Message.Message Message { get => message; set => message = value; }


        public void Execute(Message.Message message)
        {
            onMessage(message);
        }
    }
}
