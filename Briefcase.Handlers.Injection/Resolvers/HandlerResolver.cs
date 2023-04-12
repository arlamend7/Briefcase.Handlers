using Briefcase.Handlers.Base;
using Briefcase.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Briefcase.Handlers.Injection.Resolvers
{
    internal class HandlerResolver : HandlerResolverBase,  IHandler
    {
        private readonly IServiceProvider serviceProvider;

        public HandlerResolver(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public override IHandler<T> ResolveHandler<T>()
        {
            return serviceProvider?.GetService<IHandler<T>>();
        }
    }
}
