<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyConfigNoPropertyBuilder<T, TProp></small>

<i>

```csharp
public interface IPropertyConfigNoPropertyBuilder<T, TProp>
{

	public IPropertyConfigInfoBuilder<T, TProp> ForMember(Expression<Func<T, TProp>> expression, String description= ); 

	public Boolean Ignore(); 
}
```

</i>
