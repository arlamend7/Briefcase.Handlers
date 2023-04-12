<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers](../Namespace/Briefcase.Handlers.md);</small>

#### <small>EditHandlerCollection</small>

<i>

```csharp
public class EditHandlerCollection : EditHandlerBase, IEditHandler
{

	public EditHandlerCollection(IEnumerable<EditHandlerConfiguration> editHandler); 

	public IEditHandlerOperation<T> Create(); 

	public IEditHandlerOperation<T> Delete(T entity); 

	public IEditHandlerOperation<T> Edit(T entity); 
}
```

</i>


#### <small>Related items</small>

[IEditHandler](IEditHandler.md)
[EditHandlerBase](EditHandlerBase.md)