using Case.Handlers.Builder;
using Case.Handlers.Interfaces;

namespace Case.Handlers.Customizes.Interfaces
{
    public interface IEditHandlerCustomConfigutation
    {
        IEditHandlerConfigurationBuilder Builder();
    }
    public interface IEditHandlerCustomConfigutation<T> :
         IEditHandlerCustomConfigutation,
         IEditHandlerMapperConfigurarion<T, T>
         where T : class, new()
    {
        void OnCreate(IEditHandlerOperation<T> editHandler);
        void OnDelete(IEditHandlerOperation<T> editHandler);
    }
}