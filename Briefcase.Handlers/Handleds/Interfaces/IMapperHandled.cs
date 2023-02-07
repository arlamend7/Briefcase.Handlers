using System;
using System.Reflection;

namespace Case.Handlers.Handleds.Interfaces
{
    public interface IMapperHandled : IHandled
    {
        Type MapperType { get; }
        PropertyInfo MapperPropertyType { get; }
    }
}
