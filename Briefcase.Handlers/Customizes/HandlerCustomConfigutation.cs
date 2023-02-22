using Briefcase.Handlers.Builder;
using Briefcase.Handlers.Builder.Interfaces;
using Briefcase.Handlers.Customizes.Interfaces;
using Briefcase.Handlers.Interfaces;

namespace Briefcase.Handlers.Customizes
{
    public abstract class HandlerCustomConfigutation<T> :
        IEditHandlerCustomConfigutation<T>
        where T : class, new()
    {
        public abstract void ConfigureRules(IHandlerConfigurationBuilder<T> builder);

        /// <summary>
        ///     Ignore all default values of all properties
        /// </summary>
        /// <param name="mapper"></param>
        public virtual void ConfigureMapper(IMapperConfigurationBuilder<T, T> mapper)
        {
            mapper.IgnoreAllDefaultValues();
        }

        public virtual void OnCreate(T value)
        {

        }

        public virtual void OnDelete(T value)
        {

        }
        public virtual void OnEdit(T value)
        {

        }
        public IHandlerConfigurationBuilder<T> Builder()
        {
            var builder = new EditHandlerConfigurationBuilder<T>();
            ConfigureRules(builder);
            builder.OnCreate(OnCreate);
            builder.OnDelete(OnDelete);
            builder.OnEdit(OnEdit);

            var mapper = new MapperConfigurationBuilder<T, T>();
            ConfigureMapper(mapper);

            builder.SetMapper(this);

            return builder;
        }

        IHandlerConfigurationBuilder IHandlerCustomConfigutation.Builder()
        {
            return Builder();
        }
    }
}
