<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IMapperConfigurationBuilder</small>

<i>

```csharp
public interface IMapperConfigurationBuilder : IBuilderOf<MapperConfiguration>, IDisposable
{

	public IMapperConfigurationBuilder IgnoreAllDefaultValues(); 

	public IMapperConfigurationBuilder SetTypes(Type type, Type interactionType); 
}
```

</i>


#### <small>Related items</small>

[IBuilderOf<MapperConfiguration>](IBuilderOf`1.md)
[IDisposable](IDisposable.md)