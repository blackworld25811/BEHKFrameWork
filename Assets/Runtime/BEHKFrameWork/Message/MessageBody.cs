using System.Collections;
using BEHKFrameWork.Utility;

namespace BEHKFrameWork.Message
{
    public class MessageBody : Singleton<MessageBody>
    {
        private Queue bodyQueue;

        public MessageBody()
        {
            bodyQueue = new Queue();
        }

        public void clear()
        {
            bodyQueue.Clear();
        }

        public void Add(object @object)
        {
            bodyQueue.Enqueue(@object);
        }

        public object Get()
        {
            return bodyQueue.Dequeue();
        }
    }
}
