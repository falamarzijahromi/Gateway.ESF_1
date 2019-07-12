using System;
using System.Collections.Concurrent;
using DynamicServiceHost.Matcher;

namespace Gateway.Compositioning.Implementations
{
    public class TypeGlobalContainer : IGlobalTypeContainer
    {
        private readonly ConcurrentDictionary<string, Type> mapping;

        public TypeGlobalContainer()
        {
            mapping = new ConcurrentDictionary<string, Type>();
        }
        public void Save(Type type) => mapping[type.FullName] = type;

        public bool Contains(string typeName) => mapping.ContainsKey(typeName);

        public Type Get(string name) => mapping[name];
    }
}