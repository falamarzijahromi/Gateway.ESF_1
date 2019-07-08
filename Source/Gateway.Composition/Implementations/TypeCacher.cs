﻿using System.Collections.Concurrent;
using DynamicWcfServiceHost.Proxy;

namespace Gateway.Compositioning.Implementations
{
    public class TypeCacher : ITypeCacher
    {
        private readonly ConcurrentDictionary<object, object> typeMappings;

        public TypeCacher()
        {
            typeMappings = new ConcurrentDictionary<object, object>();    
        }

        public void Hold(object keyObject, object valueObject)
        {
            typeMappings[keyObject] = valueObject;
        }

        public object Get(object keyObject)
        {
            return typeMappings[keyObject];
        }

        public bool ContainesKey(object keyObject)
        {
            return typeMappings.ContainsKey(keyObject);
        }
    }
}