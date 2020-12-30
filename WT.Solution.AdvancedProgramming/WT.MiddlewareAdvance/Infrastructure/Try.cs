using System;
using System.Threading.Tasks;

namespace WT.MiddlewareAdvance.Infrastructure
{
    public class Try : MiddlewareType
    {
        public Try(Func<string,Task> func):base(func)
        {

        }
        public override async Task Handle(string msg)
        {
            try
            {
                Console.WriteLine("Try");
                await _func(msg);
            }
            catch 
            {

                
            }
        }
    }
}
