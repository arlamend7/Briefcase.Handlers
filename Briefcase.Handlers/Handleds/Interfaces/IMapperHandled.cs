using System;
using System.Reflection;

namespace Briefcase.Handlers.Handleds.Interfaces
{
    public interface IMapperHandled : IHandled
    {
        Type MapperType { get; }
        PropertyInfo MapperPropertyType { get; }
    }
}
