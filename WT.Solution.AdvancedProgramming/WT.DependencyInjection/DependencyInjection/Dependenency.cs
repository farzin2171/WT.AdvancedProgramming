using System;

namespace WT.DependencyInjection.DependencyInjection
{
    public class Dependenency
    {
        public Dependenency(Type type,DependencyLifetime lifetime)
        {
            LifeTime = lifetime;
            Type = type;
            Implemented = false;
        }
        public void AddImplementation(object implementation)
        {
            Implementation = implementation;
            Implemented = true;
        }
        public Type Type { get; set; }
        public object Implementation { get; private set; }
        public DependencyLifetime LifeTime { get; set; }
        public bool Implemented { get; private set; }
    }
}
