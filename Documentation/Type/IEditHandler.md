<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Interfaces](../Namespace/Briefcase.Handlers.Interfaces.md);</small>

#### <small>IEditHandler</small>

<i>

```csharp
public interface IEditHandler
{

	public IEditHandlerOperation<T> Create(); 

	public IEditHandlerOperation<T> Edit(T entity); 

	public IEditHandlerOperation<T> Delete(T entity); 
}
```

</i>
