using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WT.MiddlewareAdvance.Infrastructure
{
    public class PipeBuilder
    {
        List<Type> _types;
        Func<string, Task> _mainFunc;
        public PipeBuilder(Func<string, Task> mainFunc)
        {
            _types = new List<Type>();
            _mainFunc = mainFunc;
        }

        public PipeBuilder Add<T>()
        {
            _types.Add(typeof(T));
            return this;
        }

        public Func<string, Task> CreatePipe(int index)
        {
            if (index < _types.Count - 1)
            {
                var childHandle = CreatePipe(index + 1);
                var pipe = (MiddlewareType)Activator.CreateInstance(_types[index], childHandle);
                return pipe.Handle;
            }
            else
            {
                var finalFunc = (MiddlewareType)Activator.CreateInstance(_types[index], _mainFunc);
                return finalFunc.Handle;
            }
        }

        public Func<string,Task> Build()
        {
            return CreatePipe(0);
        }
    }
}
