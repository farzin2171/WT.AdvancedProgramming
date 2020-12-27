using System;
using System.Collections.Generic;
using System.Linq;

namespace WT.DependencyInjection.DependencyInjection
{
    public class Container
    {
        List<Dependenency> _dependencies;
        public Container()
        {
            _dependencies = new List<Dependenency>();
        }
        public void AddTransient<T>()
        {
            _dependencies.Add(new Dependenency(typeof(T),DependencyLifetime.Transient));
        }
        public void AddSingleton<T>()
        {
            _dependencies.Add(new Dependenency(typeof(T), DependencyLifetime.Singleton));
        }
        public Dependenency GetService<T>()
        {
            var type = typeof(T);
            return  _dependencies.FirstOrDefault(t => t.Type.Name == type.Name);
        }
        public Dependenency GetService(Type type)
        {
            return _dependencies.FirstOrDefault(t => t.Type.Name == type.Name);
        }
    }
}
