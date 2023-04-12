<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers](../Namespace/Briefcase.Handlers.md);</small>

#### <small>EditHandler<T></small>

<i>

```csharp
public class EditHandler<T> : EditHandlerBase, IEditHandler<T>
{

	public EditHandler`1(EditHandlerConfiguration configuration); 

	public IEditHandlerOperation<T> Create(); 

	public IEditHandlerOperation<T> Delete(T entity); 

	public IEditHandlerOperation<T> Edit(T entity); 

	public static IEditHandler<T> CreateUsing(Action<IEditHandlerConfigurationBuilder<T>> configurationBuilder); 
}
```

</i>


#### <small>Related items</small>

[IEditHandler<T>](IEditHandler`1.md)
[EditHandlerBase](EditHandlerBase.md)