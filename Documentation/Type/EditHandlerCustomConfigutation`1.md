<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Customizes](../Namespace/Briefcase.Handlers.Customizes.md);</small>

#### <small>EditHandlerCustomConfigutation<T></small>

<i>

```csharp
public abstract class EditHandlerCustomConfigutation<T> : IEditHandlerCustomConfigutation<T>, IEditHandlerCustomConfigutation, IEditHandlerMapperConfigurarion<T, T>
{

	public Void ConfigureRules(IEditHandlerConfigurationBuilder<T> builder); 

	public Void ConfigureMapper(IMapperConfigurationBuilder<T, T> mapper); 

	public Void OnCreate(IEditHandlerOperation<T> editHandler); 

	public Void OnDelete(IEditHandlerOperation<T> editHandler); 

	public IEditHandlerConfigurationBuilder<T> Builder(); 
}
```

</i>


#### <small>Related items</small>

[IEditHandlerCustomConfigutation<T>](IEditHandlerCustomConfigutation`1.md)
[IEditHandlerCustomConfigutation](IEditHandlerCustomConfigutation.md)
[IEditHandlerMapperConfigurarion<T, T>](IEditHandlerMapperConfigurarion`2.md)