using System;
using System.Threading.Tasks;

namespace WT.MiddlewareAdvance.Infrastructure
{
    public class Wrap : MiddlewareType
    {
        public Wrap(Func<string,Task> func):base(func)
        {

        }
        public override async Task Handle(string msg)
        {
            Console.WriteLine("Wrap Started");
            await _func(msg);
            Console.WriteLine("Wrap End");
        }
    }
}
