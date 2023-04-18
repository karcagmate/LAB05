using Backend.Model;

namespace Backend.Logic
{
    public class MessagLogic : IMessagLogic
    {
        IList<MessageModel> messages;
        public void SetupCollection(IList<MessageModel> messages)
        {
            this.messages = messages;
        }
        public void Add(MessageModel message)
        {
            message.Date = DateTime.Now;
            messages.Add(message);
        }
    }
}
