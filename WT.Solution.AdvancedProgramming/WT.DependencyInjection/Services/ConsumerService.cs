namespace WT.DependencyInjection.Services
{
    public class ConsumerService
    {
        private PrintService _printService;

        public ConsumerService(PrintService printService)
        {
            _printService = printService;
        }
        public void RepeatMessage(int repeatCount,string message)
        {
            for (int i = 0; i < repeatCount; i++)
            {
                _printService.PrintLine(message);
            }
        }
    }
}
