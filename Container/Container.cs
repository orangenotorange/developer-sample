using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private  readonly Dictionary<Type, Type> _types = new();

        public void Bind(Type interfaceType, Type implementationType)
        {
            _types.Add(interfaceType, implementationType);
        }

        public T Get<T>()
        {
            var hasValue = _types.TryGetValue(typeof(T), out var implementationType);
            if (hasValue)
            {
                return (T)Activator.CreateInstance(implementationType);    
            }

            throw new Exception("No valid interface");
        }
    }
}