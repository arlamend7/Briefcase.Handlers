<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IEditHandlerConfigurationBuilder<T></small>

<i>

```csharp
public interface IEditHandlerConfigurationBuilder<T> : IEditHandlerConfigurationBuilder, IBuilderOf<EditHandlerConfiguration>, IDisposable
{

	public IEditHandlerConfigurationBuilder<T> CreateMapper(Action<IMapperConfigurationBuilder<T, TMapper>> configureMapper); 

	public IEditHandlerConfigurationBuilder<T> ForProperty(Expression<Func<T, TProp>> expression, Func<IPropertyConfigInfoBuilder<T, TProp>, Boolean> configurationMethod); 

	public IEditHandlerConfigurationBuilder<T> SetMapper(IEditHandlerMapperConfigurarion<T, TMapper> editHandlerMapperConfig); 
}
```

</i>


#### <small>Related items</small>

[IEditHandlerConfigurationBuilder](IEditHandlerConfigurationBuilder.md)
[IBuilderOf<EditHandlerConfiguration>](IBuilderOf`1.md)
[IDisposable](IDisposable.md)