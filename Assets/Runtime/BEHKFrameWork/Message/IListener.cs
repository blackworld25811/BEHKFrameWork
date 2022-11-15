namespace BEHKFrameWork.Message
{
    /// <summary>
    /// many of message combind one listener
    /// </summary>
    internal interface IListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IData GetData(string name);

        /// <summary>
        /// need listen to message name
        /// </summary>
        /// <returns></returns>
        string[] ListMessageInterests();

        /// <summary>
        /// message logic
        /// </summary>
        /// <param name="message"></param>
        void HandleMessage(Message message);
    }
}
