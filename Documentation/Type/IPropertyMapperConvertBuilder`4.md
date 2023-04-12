<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp></small>

<i>

```csharp
public interface IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> : IPropertyMapperConvertBuilderConverted<TRequestProp, TRequestProp, TProp>
{

	Boolean UseSameValue { get; }

	public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, Boolean> ignoreCondition, String message= ); +1 overloads

	public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreDefaultValue(String message= ); 
}
```

</i>


---

#### IgnoreIf

<small><b>Return:</b> IPropertyMapperConvertBuilder\<T, TProp, TRequest, TRequestProp></small>

<i>

```csharp
public interface IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> : IPropertyMapperConvertBuilderConverted<TRequestProp, TRequestProp, TProp>
{

	public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, Boolean> ignoreCondition, String message= );

	public IPropertyMapperConvertBuilder<T, TProp, TRequest, TRequestProp> IgnoreIf(Func<TRequestProp, Boolean> ignoreCondition, Func<TRequestProp, String> messageFunc);
}
```

</i>

#### <small>Related items</small>

[IPropertyMapperConvertBuilderConverted<TRequestProp, TRequestProp, TProp>](IPropertyMapperConvertBuilderConverted`3.md)