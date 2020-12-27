using System;

namespace WT.DependencyInjection.Services
{
    public class MessageService
    {
        Guid guid;
        public MessageService()
        {
            guid = Guid.NewGuid();
        }
        public string Message(string msg)
        {
            return $" {msg} - {guid} ";
        }
    }
}
