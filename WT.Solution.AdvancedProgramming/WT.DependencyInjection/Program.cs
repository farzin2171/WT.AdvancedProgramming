using System;
using WT.DependencyInjection.DependencyInjection;
using WT.DependencyInjection.Services;

namespace WT.DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintService printService = new PrintService();
            //ConsumerService consumerService = new ConsumerService(printService);
            //consumerService.RepeatMessage(100, "Hellow world");

            Container container = new Container();
            container.AddSingleton<PrintService>();
            container.AddTransient<ConsumerService>();
            container.AddSingleton<MessageService>();
            var resolver = new Resolver(container);

            //var service= container.GetService<PrintService>();
            //((PrintService)Activator.CreateInstance(service)).PrintLine("hellow world");

            //var printService = resolver.Resolve<PrintService>();
            //printService.PrintLine("Hellow wordl");

            var consumerService = resolver.Resolve<ConsumerService>();
            consumerService.RepeatMessage(5,"Hellow wordl");

            var consumerService2 = resolver.Resolve<ConsumerService>();
            consumerService2.RepeatMessage(5, "Hellow wordl");

            Console.ReadLine();
        }
    }
}
