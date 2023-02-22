using Briefcase.Handlers.Base;
using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Briefcase.Handlers
{
    internal class HandlerCollection : HandlerResolverBase, IHandlerCollection
    {
        private static List<HandlerConfiguration> _handlerConfigurations;

        public HandlerCollection()
        {
            _handlerConfigurations = new List<HandlerConfiguration>();
        }

        public void Add(HandlerConfiguration handlerConfiguration)
        {
            _handlerConfigurations.Add(handlerConfiguration);
        }

        public void AddRange(IEnumerable<HandlerConfiguration> handlersConfigurations)
        {
            _handlerConfigurations.AddRange(handlersConfigurations);
        }

       
        public override IHandler<T> ResolveHandler<T>()
        {
            var configuration = _handlerConfigurations.FirstOrDefault(x => x.Type == typeof(T));
            if(configuration != null)
                return new Handler<T>(configuration);
            return null;
        }
    }
}
