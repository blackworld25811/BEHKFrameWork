namespace BEHKFrameWork.Message
{
    /// <summary>
    /// many of message combind one listener
    /// </summary>
    public interface IListener
    {
        /// <summary>
        /// need listen to message name
        /// </summary>
        /// <returns></returns>
        string[] ListMessageInterests();

        /// <summary>
        /// message logic
        /// </summary>
        /// <param name="message"></param>
        void HandleMessageAsync(Message message);
    }
}
