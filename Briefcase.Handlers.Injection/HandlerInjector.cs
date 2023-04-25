using Briefcase.Handlers.Configurations;
using Briefcase.Handlers.Customizes.Interfaces;
using Briefcase.Handlers.Injection.Resolvers;
using Briefcase.Handlers.Interfaces;
using Briefcase.System.Retrivers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Briefcase.Handlers.Injection
{
    public static class HandlerInjector
    {
        public static IServiceCollection UseHandlers(this IServiceCollection services, params Assembly[] assemblies)
        {
            return services.InjectHandlerCustomConfigurations(out IEnumerable<Type> allTypesWithCustomConfiguration, assemblies)
                           .InjectHandlerMappers(assemblies)
                           .InjectHandlers(allTypesWithCustomConfiguration);
        }

        private static IServiceCollection InjectHandlerCustomConfigurations(this IServiceCollection services, out IEnumerable<Type> allTypesWithCustomConfiguration, params Assembly[] assemblies)
        {
            var types =
                RetriverHelper.Get(typeof(IEditHandlerCustomConfigutation<>))
                              .AsInterface()
                              .On(assemblies)
                              .WhereImplementItAsOneOfInterface();

            allTypesWithCustomConfiguration =
                types.SelectMany(x => x.interfaces.Select(y => y.GenericTypeArguments[0]));


            Func<Type, IServiceProvider,Type, object> editHandlerConfiguration = (item, x, parameter) =>
            {
                var service = x.GetService(item) as IHandlerCustomConfigutation;
                var builder = service.Builder();

                foreach (var mapper in x.GetServices<MapperConfiguration>().Where(x => x.Type == item.GenericTypeArguments[0] && x.InteractioType != item.GenericTypeArguments[0]))
                {
                    builder.SetMapper(mapper);
                }

                return typeof(HandlerConfiguration<>).MakeGenericType(parameter).GetConstructor(new Type[1] { typeof(HandlerConfiguration) }).Invoke(new object[1] { builder.Build() });
            };

            foreach ((Type type, IEnumerable<Type> interfaces) in types)
            {
                var interfaceImplementation = interfaces.Single();
                var parameters = interfaceImplementation.GenericTypeArguments;
                services
                    .AddScoped(interfaceImplementation, type)
                    .AddScoped(typeof(HandlerConfiguration<>).MakeGenericType(parameters), x => editHandlerConfiguration(interfaceImplementation, x, parameters[0]));
            }
            return services;
        }

        private static IServiceCollection InjectHandlerMappers(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types =
               RetriverHelper.Get(typeof(IHandlerMapperConfigurarion<,>))
                             .AsInterface()
                             .On(assemblies)
                             .WhereImplementItAsOneOfInterface();


            Func<Type, Type, IServiceProvider, MapperConfiguration> mapperBuilderFunc = (item, type, sericeProvider) =>
            {
                var service = sericeProvider.GetService(type);
                var interfaceImplementation = typeof(IHandlerMapperConfigurarion<,>).MakeGenericType(item.GenericTypeArguments);
                return interfaceImplementation.GetMethod("Build").Invoke(service, new object[0]) as MapperConfiguration;
            };

            foreach ((Type type, IEnumerable<Type> interfaces) in types)
            {
                foreach (var item in interfaces)
                {
                    services
                        .AddScoped(type)
                        .AddScoped(item, type)
                        .AddScoped(typeof(MapperConfiguration), x => mapperBuilderFunc(item ,type, x));
                }
            }

            return services;
        }

        private static IServiceCollection InjectHandlers(this IServiceCollection services, IEnumerable<Type> allTypesWithCustomConfiguration)
        {
            foreach (var item in allTypesWithCustomConfiguration)
            {
                services.AddScoped(typeof(IHandler<>).MakeGenericType(item), x =>
                {
                    var specificConfiguration = typeof(HandlerConfiguration<>).MakeGenericType(item);

                    return typeof(IHandler<>).MakeGenericType(item).GetMethod("CreateUsing", new Type[1] { typeof(HandlerConfiguration) })
                    .Invoke(null, new object[1] { x.GetService(specificConfiguration) as HandlerConfiguration });
                });
            }

            return services.AddSingleton<IHandler>(x => new HandlerResolver(x));
        }

    }
}
