<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyConfigInfoBuilder<T, TProp></small>

<i>

```csharp
public interface IPropertyConfigInfoBuilder<T, TProp> : IPropertyConfigBuilder<T, TProp>
{

	public IPropertyConfigBuilder<T, TProp> FormatAfterChanged(Func<TProp, TProp> prop); 

	public Boolean Ignore(); 
}
```

</i>


#### <small>Related items</small>

[IPropertyConfigBuilder<T, TProp>](IPropertyConfigBuilder`2.md)