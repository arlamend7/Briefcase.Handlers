using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Handleds.Interfaces;
using System;
using System.Reflection;

namespace Briefcase.Handlers.Handleds
{
    internal abstract class MapperHandledDetail
        : HandledDetail, IMapperHandled
    {
        public Type MapperType { get; }
        public PropertyInfo MapperPropertyType { get; }
        public MapperHandledDetail(Type mapperType, PropertyInfo mapperPropertyType, object originalValue, PropertyInfo property, object value, HandledStopStageEnum stopedStage)
            : base(property, value, stopedStage, originalValue)
        {
            MapperType = mapperType;
            MapperPropertyType = mapperPropertyType;
        }


    }
}
