using System;
using System.Collections.Generic;

namespace Briefcase.Handlers.Configurations
{
    public class MapperConfiguration
    {
        public Type Type { get; protected set; }
        public Type InteractioType { get; protected set; }
        public IEnumerable<PropertyMapperConfiguration> Properties { get; protected set; }
        public MapperConfiguration()
        {
            Properties = new PropertyMapperConfiguration[0];
        }
    }
}