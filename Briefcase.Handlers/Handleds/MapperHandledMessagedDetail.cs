using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Handleds.Interfaces;
using System;
using System.Reflection;

namespace Briefcase.Handlers.Handleds
{
    internal class MapperHandledMessagedDetail
        : MapperHandledDetail, IHandledMessaged, IMapperHandled
    {
        public string Message { get; }
        public MapperHandledMessagedDetail(Type mapperType, PropertyInfo mapperPropertyType, object originalValue, PropertyInfo property, object value, HandledStopStageEnum stopedStage, string message)
        : base(mapperType, mapperPropertyType, originalValue, property, value, stopedStage)
        {
            Message = message;
        }

    }
}
