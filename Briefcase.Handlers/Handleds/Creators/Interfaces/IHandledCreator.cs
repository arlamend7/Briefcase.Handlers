using Briefcase.Handlers.Handleds.Enums;
using Briefcase.Handlers.Handleds.Interfaces;
using Briefcase.Handlers.Configurations;
using System;

namespace Briefcase.Handlers.Handleds.Creators.Interfaces
{
    public interface IHandledCreator : IDisposable
    {
        IHandled StopedOn(object value, HandledStopStageEnum stopedEnum, string message);
        IHandled StopedOnMapper(object value, HandledStopStageEnum stopedEnum, string message);
        IHandled Successfully(object value, object lastValue);
    }
}