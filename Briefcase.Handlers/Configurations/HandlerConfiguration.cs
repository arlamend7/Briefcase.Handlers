using System;
using System.Collections.Generic;

namespace Briefcase.Handlers.Configurations
{
    public class HandlerConfiguration
    {
        public Type Type { get; protected set; }
        public IEnumerable<PropertyConfiguration> Properties { get; protected set; }
        public IEnumerable<MapperConfiguration> EditMappers { get; protected set; }
        public Action<object> OnCreate { get; protected set; }
        public Action<object> OnEdit { get; protected set; }
        public Action<object> OnDelete { get; protected set; }
        public HandlerConfiguration()
        {
            Properties = new PropertyConfiguration[0];
            EditMappers = new MapperConfiguration[0];
        }

    }
    public class HandlerConfiguration<T> : HandlerConfiguration
    {
        public HandlerConfiguration(HandlerConfiguration editHandler)
        {
            if (editHandler.Type != typeof(T))
                throw new Exception("Handler de tipagem diferente");
            Type = editHandler.Type;
            Properties = editHandler?.Properties;
            EditMappers = editHandler.EditMappers;
        }
    }
}