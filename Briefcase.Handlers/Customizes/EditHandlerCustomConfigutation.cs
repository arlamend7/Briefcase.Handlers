using Case.Handlers.Builder;
using Case.Handlers.Customizes.Interfaces;
using Case.Handlers.Interfaces;
using System;

namespace Case.Handlers.Customizes
{
    public abstract class EditHandlerCustomConfigutation<T> :
        IEditHandlerCustomConfigutation<T>
        where T : class, new()
    {
        public virtual void ConfigureRules(EditHandlerConfigurationBuilder<T> builder) { }

        /// <summary>
        ///     Ignore all default values of all properties
        /// </summary>
        /// <param name="mapper"></param>
        public virtual void ConfigureMapper(MapperConfigurationBuilder<T, T> mapper)
        {
            mapper.IgnoreAllDefaultValues();
        }

        public virtual void OnCreate(IEditHandlerOperation<T> editHandler)
        {
        }

        public virtual void OnDelete(IEditHandlerOperation<T> editHandler)
        {

        }

        public EditHandlerConfigurationBuilder<T> Builder()
        {
            var mapper = new MapperConfigurationBuilder<T, T>();
            ConfigureMapper(mapper);

            var builder = new EditHandlerConfigurationBuilder<T>();
            builder.SetMapper(this);

            return builder;
        }

        EditHandlerConfigurationBuilder IEditHandlerCustomConfigutation.Builder()
        {
            return Builder();
        }
    }
}
