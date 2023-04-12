<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyMapperBuilder<T, TRequest, TProp></small>

<i>

```csharp
public interface IPropertyMapperBuilder<T, TRequest, TProp> : IPropertyMapperBuilder<TProp>
{

	public Boolean Ignore(); 

	public IPropertyMapperConvertBuilder<T, TProp, TRequest, TProp> MapFrom(Expression<Func<TRequest, TProp>> getValue); 

	public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> MapFrom(Expression<Func<TRequest, TRequestProp>> getValue); 

	public Boolean MapExactlyFrom(Expression<Func<TRequest, TProp>> getValue); 
}
```

</i>


#### <small>Related items</small>

[IPropertyMapperBuilder<TProp>](IPropertyMapperBuilder`1.md)