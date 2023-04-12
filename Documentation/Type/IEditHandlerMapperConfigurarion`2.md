<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Customizes.Interfaces](../Namespace/Briefcase.Handlers.Customizes.Interfaces.md);</small>

#### <small>IEditHandlerMapperConfigurarion<T, TMapper></small>

<i>

```csharp
public interface IEditHandlerMapperConfigurarion<T, TMapper>
{

	public Void ConfigureMapper(IMapperConfigurationBuilder<T, TMapper> builder); 

	public MapperConfiguration Build(); 
}
```

</i>
