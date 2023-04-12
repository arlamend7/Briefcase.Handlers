<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Customizes.Interfaces](../Namespace/Briefcase.Handlers.Customizes.Interfaces.md);</small>

#### <small>IEditHandlerCustomConfigutation<T></small>

<i>

```csharp
public interface IEditHandlerCustomConfigutation<T> : IEditHandlerCustomConfigutation, IEditHandlerMapperConfigurarion<T, T>
{

	public Void OnCreate(IEditHandlerOperation<T> editHandler); 

	public Void OnDelete(IEditHandlerOperation<T> editHandler); 
}
```

</i>


#### <small>Related items</small>

[IEditHandlerCustomConfigutation](IEditHandlerCustomConfigutation.md)
[IEditHandlerMapperConfigurarion<T, T>](IEditHandlerMapperConfigurarion`2.md)