using Coordination.ESF_1;
using DynamicTypeGenerator.Abstracts;
using DynamicTypeGenerator.Invokations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gateway.Compositioning.Implementations
{
    public class CommandsInvokationEvaluator : IInvokationEvaluator, IDisposable
    {
        private object disconnectedProxy;
        private object connectedProxy;

        public CommandsInvokationEvaluator(object connectedProxy, object disconnectedProxy)
        {
            this.connectedProxy = connectedProxy;
            this.disconnectedProxy = disconnectedProxy;
        }

        public object Evaluate(InvokationContext context)
        {
            if (context.MethodName == "Dispose")
            {
                Dispose();

                return null;
            }

            return InvokeProxy(context.MethodName, context.Parameters);
        }

        public void Dispose()
        {
            connectedProxy = null;
            disconnectedProxy = null;
        }

        private object InvokeProxy(string contextMethodName, List<ArgInfo> contextParameters)
        {
            switch (Interaction.Mode)
            {
                case InteractionModes.Direct:
                    return InvokeProxy(connectedProxy, contextMethodName, contextParameters);
                case InteractionModes.Indirect:
                    return InvokeProxy(disconnectedProxy, contextMethodName, contextParameters);
                case InteractionModes.NotSet:
                default:
                    throw new NotSupportedException("Calling command proxies must be in either connected or disconnected scope.");
            }
        }

        private object InvokeProxy(object proxy, string contextMethodName, List<ArgInfo> contextParameters)
        {
            var methodInfo = proxy.GetType().GetMethod(contextMethodName);

            var @params = contextParameters.Select(param => param.ParamObject).ToArray();

            return methodInfo.Invoke(proxy, @params);
        }
    }
}