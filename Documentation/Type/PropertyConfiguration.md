<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Configurations](../Namespace/Briefcase.Handlers.Configurations.md);</small>

#### <small>PropertyConfiguration</small>

<i>

```csharp
public class PropertyConfiguration
{

	PropertyInfo PropertyInfo { get; set; }

	IEnumerable<ThrowErrorIf> ErrorsValidations { get; set; }

	IEnumerable<Func<Object, Boolean>> IgnoreConditions { get; set; }

	Func<Object, Object> Formatter { get; set; }

	String Description { get; set; }

	Boolean Ignore { get; set; }

	public static ThrowErrorIf Convert(Func<T, TProp, Boolean> action, Func<TProp, String> errorMessageFunc); 
}
```

</i>
