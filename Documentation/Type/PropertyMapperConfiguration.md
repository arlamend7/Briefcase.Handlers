<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Configurations](../Namespace/Briefcase.Handlers.Configurations.md);</small>

#### <small>PropertyMapperConfiguration</small>

<i>

```csharp
public class PropertyMapperConfiguration
{

	Type MappedType { get; set; }

	PropertyInfo MappedProperty { get; set; }

	PropertyInfo Property { get; set; }

	Boolean Ignored { get; set; }

	IEnumerable<IgnoreifMessage> IgnoreConditions { get; set; }

	IEnumerable<TryConvertMessage> Converters { get; set; }

	IgnoreifMessage IgnoreDefaultValueFunc { get; }

	public IgnoreifMessage IgnoreDefaultValueFuncMessage(Func<T, String> errorMessage); 

	public static TryConvertMessage ConvertToConvert(Func<T, TType> action, Func<T, String> errorMessageFunc); +1 overloads

	public static IgnoreifMessage ConvertToIgnore(Func<T, Boolean> action, Func<T, String> errorMessageFunc); 
}
```

</i>


---

#### ConvertToConvert

<small><b>Return:</b> TryConvertMessage</small>

<i>

```csharp
public class PropertyMapperConfiguration
{

	public static TryConvertMessage ConvertToConvert(Func<T, TType> action, Func<T, String> errorMessageFunc);

	public static TryConvertMessage ConvertToConvert(TryConvert<T, TType> action, Func<T, String> errorMessageFunc);
}
```

</i>