using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Interfaces;

namespace Briefcase.Handlers.Customizes.Interfaces
{
    public interface IHandlerCustomConfigutation
    {
        IHandlerConfigurationBuilder Builder();
    }
    public interface IEditHandlerCustomConfigutation<T> :
         IHandlerCustomConfigutation,
         IHandlerMapperConfigurarion<T, T>
         where T : class, new()
    {
        void OnCreate(T value);
        void OnDelete(T value);
        void OnEdit(T value);
    }
}