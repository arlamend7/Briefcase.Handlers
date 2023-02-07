using Case.Handlers.Configurations;
using Case.Handlers.Handleds.Enums;
using Case.Handlers.Handleds.Interfaces;
using System;

namespace Case.Handlers.Handleds.Creators.Interfaces
{
    public interface IHandledCreator : IDisposable
    {
        IHandled StopedOn(object value, HandledStopStageEnum stopedEnum, string message);
        IHandled StopedOnMapper(object value, HandledStopStageEnum stopedEnum, string message);
        IHandled Successfully(object value, object lastValue);
    }
}