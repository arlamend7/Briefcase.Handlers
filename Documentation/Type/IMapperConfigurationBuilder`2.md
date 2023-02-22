<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IMapperConfigurationBuilder<T, TRequest></small>

<i>

```csharp
public interface IMapperConfigurationBuilder<T, TRequest> : IMapperConfigurationBuilder, IBuilderOf<MapperConfiguration>, IDisposable
{

	public IMapperConfigurationBuilder<T, TRequest> ForProperty(Expression<Func<T, TProp>> expression, Func<IPropertyMapperBuilder<T, TRequest, TProp>, Boolean> configurationMethod); 

	///<summary>
	///	It will ignore all default values for all not configurated properties
	///</summary>
	public IMapperConfigurationBuilder<T, TRequest> IgnoreAllDefaultValues(); 
}
```

</i>


#### <small>Related items</small>

[IMapperConfigurationBuilder](IMapperConfigurationBuilder.md)
[IBuilderOf<MapperConfiguration>](IBuilderOf`1.md)
[IDisposable](IDisposable.md)