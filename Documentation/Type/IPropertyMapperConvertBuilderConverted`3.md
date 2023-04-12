<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyMapperConvertBuilderConverted<TRequest, TRequestProp, TProp></small>

<i>

```csharp
public interface IPropertyMapperConvertBuilderConverted<TRequest, TRequestProp, TProp>
{

	public Boolean ConvertUsing(Func<TRequest, TProp> converter, String message= ); +1 overloads

	public IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing(Func<TRequest, TAnotherType> converter, Func<TRequest, String> message); 

	public IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing(Func<TRequest, TAnotherType> converter, String message= ); 

	public IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing(TryConvert<TRequest, TAnotherType> converter, Func<TRequest, String> message); 

	public IPropertyMapperConvertBuilderConverted<TAnotherType, TAnotherType, TProp> ConvertUsing(TryConvert<TRequest, TAnotherType> converter, String message); 
}
```

</i>


---

#### ConvertUsing

<small><b>Return:</b> Boolean</small>

<i>

```csharp
public interface IPropertyMapperConvertBuilderConverted<TRequest, TRequestProp, TProp>
{

	public Boolean ConvertUsing(Func<TRequest, TProp> converter, String message= );

	public Boolean ConvertUsing(Func<TRequest, TProp> converter, Func<TRequest, String> message);
}
```

</i>