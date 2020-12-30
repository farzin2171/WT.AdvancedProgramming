using System;
using System.Threading.Tasks;

namespace WT.MiddlewareAdvance.Infrastructure
{
    public abstract class MiddlewareType
    {
        protected Func<string, Task> _func;
        public MiddlewareType(Func<string, Task> func)
        {
            _func = func;
        }
        public abstract Task Handle(string msg);
    }
}
