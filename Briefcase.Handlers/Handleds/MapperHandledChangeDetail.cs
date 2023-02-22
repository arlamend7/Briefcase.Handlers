using Briefcase.Handlers.Handleds.Interfaces;
using System;
using System.Reflection;

namespace Briefcase.Handlers.Handleds
{
    internal class MapperHandledChangeDetail
        : HandledChangeDetail, IMapperHandled, IHandledChange
    {
        public Type MapperType { get; }
        public PropertyInfo MapperPropertyType { get; }

        public MapperHandledChangeDetail(Type mapperType, PropertyInfo mapperPropertyType, object originalValue, PropertyInfo property, object value, object lastValue)
            : base(property, value, originalValue, lastValue)
        {
            MapperType = mapperType;
            MapperPropertyType = mapperPropertyType;
        }


    }
}
