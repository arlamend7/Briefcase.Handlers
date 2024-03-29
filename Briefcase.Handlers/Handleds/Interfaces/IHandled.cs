﻿using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Handleds.Extensions;
using System.Reflection;

namespace Briefcase.Handlers.Handleds.Interfaces
{
    public interface IHandled
    {
        PropertyInfo Property { get; }
        object OriginalValue { get; }
        object Value { get; }
        abstract HandledStopStageEnum StopedStage { get; }

        bool IsIgnore => StopedStage.IsIgnored();
        bool IsError => !ChangedProperty && !IsIgnore;
        bool ChangedProperty => this is IHandledChange;
        bool IsFromMapper => this is IMapperHandled;
    }
}
