using System;
using System.Collections.Generic;

namespace Case.Handlers.Configurations
{
    public class EditHandlerConfiguration
    {
        public Type Type { get; protected set; }
        public IEnumerable<PropertyConfiguration> Properties { get; protected set; }
        public IEnumerable<MapperConfiguration> EditMappers { get; protected set; }
        public EditHandlerConfiguration()
        {
            Properties = new PropertyConfiguration[0];
            EditMappers = new MapperConfiguration[0];
        }

    }
    public class EditHandlerConfiguration<T> : EditHandlerConfiguration
    {
        public EditHandlerConfiguration(EditHandlerConfiguration editHandler)
        {
            if (editHandler.Type != typeof(T))
                throw new Exception("Handler de tipagem diferente");
            Type = editHandler.Type;
            Properties = editHandler?.Properties;
            EditMappers = editHandler.EditMappers;
        }
    }
}