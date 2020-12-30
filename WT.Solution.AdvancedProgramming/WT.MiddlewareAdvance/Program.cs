using System;
using System.Threading.Tasks;
using WT.MiddlewareAdvance.Infrastructure;

namespace WT.MiddlewareAdvance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Middleware Pipleine");
            var pipes = new PipeBuilder(FunctionA).Add<Wrap>().Add<Try>().Build();
            pipes("My message");
            Console.ReadLine();
        }

        private static async Task FunctionA(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
