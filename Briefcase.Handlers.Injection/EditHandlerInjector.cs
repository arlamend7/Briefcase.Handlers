using Case.Handlers.Builder;
using Case.Handlers.Configurations;
using Case.Handlers.Customizes.Interfaces;
using Case.Handlers.Interfaces;
using Case.System.Retrivers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Case.Handlers.Injection
{
    public static class EditHandlerInjector
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


            Func<Type, IServiceProvider, EditHandlerConfiguration> editHandlerConfiguration = (item, x) =>
            {
                var service = x.GetService(item) as IEditHandlerCustomConfigutation;
                var builder = service.Builder();

                foreach (var mapper in x.GetServices<MapperConfiguration>().Where(x => x.Type == item.GenericTypeArguments[0] && x.InteractioType != item.GenericTypeArguments[0]))
                {
                    builder.SetMapper(mapper);
                }

                return builder.Build();
            };

            foreach ((Type type, IEnumerable<Type> interfaces) in types)
            {
                var interfaceImplementation = interfaces.Single();
                var parameters = interfaceImplementation.GenericTypeArguments;
                services
                    .AddSingleton(interfaceImplementation, type)
                    .AddSingleton(typeof(EditHandlerConfiguration), x => editHandlerConfiguration(interfaceImplementation, x))
                    .AddSingleton(typeof(EditHandlerConfiguration<>).MakeGenericType(parameters), x => editHandlerConfiguration(interfaceImplementation, x));
            }
            return services;
        }

        private static IServiceCollection InjectHandlerMappers(this IServiceCollection services, params Assembly[] assemblies)
        {
            var types =
               RetriverHelper.Get(typeof(IEditHandlerMapperConfigurarion<,>))
                             .AsInterface()
                             .On(assemblies)
                             .WhereImplementItAsOneOfInterface();


            Func<Type, IServiceProvider, MapperConfiguration> mapperBuilderFunc = (item, sericeProvider) =>
            {
                var service = sericeProvider.GetService(item);
                var interfaceImplementation = typeof(IEditHandlerMapperConfigurarion<,>).MakeGenericType(item.GenericTypeArguments);
                return interfaceImplementation.GetMethod("Build").Invoke(service, new object[0]) as MapperConfiguration;
            };

            foreach ((Type type, IEnumerable<Type> interfaces) in types)
            {
                foreach (var item in interfaces)
                {
                    services
                        .AddSingleton(type)
                        .AddSingleton(item, type)
                        .AddSingleton(typeof(MapperConfiguration), x => mapperBuilderFunc(item, x));
                }
            }

            return services;
        }

        private static IServiceCollection InjectHandlers(this IServiceCollection services, IEnumerable<Type> allTypesWithCustomConfiguration)
        {
            foreach (var item in allTypesWithCustomConfiguration)
            {
                services.AddSingleton(typeof(IEditHandler<>).MakeGenericType(item), x =>
                {
                    var specificConfiguration = typeof(EditHandlerConfiguration<>).MakeGenericType(item);

                    return typeof(EditHandler<>).MakeGenericType(item).GetConstructor(new Type[1] { typeof(EditHandlerConfiguration) })
                    .Invoke(new object[1] { x.GetService(specificConfiguration) as EditHandlerConfiguration });
                });
            }
            return services.AddSingleton<IEditHandler>(x =>
            {
                return new EditHandlerCollection(x.GetServices<EditHandlerConfiguration>());
            });
        }

    }
}
