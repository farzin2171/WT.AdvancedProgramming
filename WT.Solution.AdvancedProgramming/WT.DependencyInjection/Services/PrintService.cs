using System;

namespace WT.DependencyInjection.Services
{
    public class PrintService
    {
        private MessageService _messageService;
        private Guid guid;

        public PrintService(MessageService messageService)
        {
            _messageService = messageService;
            guid = Guid.NewGuid();
        }
        public void PrintLine(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"#{guid} ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(_messageService.Message(msg));
        }
    }
}
