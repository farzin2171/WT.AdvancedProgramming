using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WT.DependencyInjection.DependencyInjection
{
    public class Resolver
    {
        private Container _container;

        public Resolver(Container container)
        {
            _container = container;
        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        public object Resolve(Type t)
        {
            var dependenency = _container.GetService(t);
            var constructor = dependenency.Type.GetConstructors().Single();
            var parameters = constructor.GetParameters().ToArray();
            if (parameters.Length > 0)
            {
                var implimentations = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    implimentations[i] = Resolve(parameters[i].ParameterType);
                }
                return  CreateImplimentation(dependenency,t=> Activator.CreateInstance(t, implimentations));
            }
            return   CreateImplimentation(dependenency,t=> Activator.CreateInstance(t));
        }

        public object CreateImplimentation(Dependenency dependenency,Func<Type,object> factory)
        {
            if(dependenency.Implemented)
            {
                return dependenency.Implementation;
            }
            var implementation = factory(dependenency.Type);
            if(dependenency.LifeTime==DependencyLifetime.Singleton)
            {
                dependenency.AddImplementation(implementation);
            }
            return implementation;
        }
    }
}
