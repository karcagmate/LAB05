using Backend.Model;

namespace Backend.Logic
{
    public interface IMessagLogic
    {
        void Add(MessageModel message);
        void SetupCollection(IList<MessageModel> messages);
    }
}