using Case.Handlers.Handleds.Enums;

namespace Case.Handlers.Handleds.Extensions
{
    public static class HandledStopStageEnumExtensions
    {
        public static bool IsIgnored(this HandledStopStageEnum stoped)
        {
            if(stoped is HandledStopStageEnum.IgnoreOnMapping 
            || stoped is HandledStopStageEnum.IgnoreAfterConvert
            || stoped is HandledStopStageEnum.IgnoreBeforeConvert
            || stoped is HandledStopStageEnum.IgnoreAfterSet)
                return true;
            return false;
        }
        public static bool IsError(this HandledStopStageEnum stoped)
        {
            if (stoped is HandledStopStageEnum.SetValue || stoped.IsIgnored())
                return false;
            return true;
        }
    }
}
