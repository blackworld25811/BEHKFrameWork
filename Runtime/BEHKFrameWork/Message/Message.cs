namespace BEHKFrameWork.Message
{
    /// <summary>
    /// one message must be have an observer
    /// </summary>
    public class Message
    {
        private string name;

        private string type;

        private object body;

        /// <summary>
        /// Message's name,is must uniqueness
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        ///  Message's type,used to define different types
        ///  sush as net type,logic type,and so on
        /// </summary>
        public string Type { get => type; set => type = value; }
        /// <summary>
        /// Message's content,is can be everything
        /// </summary>
        public object Body { get => body; set => body = value; }

        public Message(string name, string type, object body)
        {
            Name = name;
            Type = type;
            Body = body;
        }
    }
}
