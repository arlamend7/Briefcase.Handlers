using Case.Handlers.Handleds.Enums;
using Case.Handlers.Handleds.Interfaces;
using System;
using System.Reflection;

namespace Case.Handlers.Handleds
{
    public class MapperHandledMessagedDetail
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
