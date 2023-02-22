<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyMapperBuilder<TProp></small>

<i>

```csharp
public interface IPropertyMapperBuilder<TProp>
{

	public IPropertyMapperBuilder<TProp> IgnoreValue(TProp ignoredValue, String message= ); 

	public IPropertyMapperBuilder<TProp> IgnoreDefaultValue(String message= ); 
}
```

</i>
