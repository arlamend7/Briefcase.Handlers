<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Builder.Interfaces](../Namespace/Briefcase.Handlers.Builder.Interfaces.md);</small>

#### <small>IPropertyConfigBuilder<T, TProp></small>

<i>

```csharp
public interface IPropertyConfigBuilder<T, TProp>
{

	Boolean Conclude { get; }

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, Boolean> action, Func<TProp, String> errorMessageFunc= ); +1 overloads

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, Boolean> action, Func<TProp, String> errorMessageFunc= ); +1 overloads

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValueIs(TProp value, String errorMessage= ); 

	public IPropertyConfigBuilder<T, TProp> IgnoreIfValueIs(TProp ignore); 

	public IPropertyConfigBuilder<T, TProp> IgnoreIf(Func<TProp, Boolean> ignore); 
}
```

</i>


---

#### ThrowErrorIf

<small><b>Return:</b> IPropertyConfigBuilder\<T, TProp></small>

<i>

```csharp
public interface IPropertyConfigBuilder<T, TProp>
{

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, Boolean> action, Func<TProp, String> errorMessageFunc= );

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIf(Func<T, TProp, Boolean> action, String errorMessage= );
}
```

</i>

---

#### ThrowErrorIfValue

<small><b>Return:</b> IPropertyConfigBuilder\<T, TProp></small>

<i>

```csharp
public interface IPropertyConfigBuilder<T, TProp>
{

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, Boolean> action, Func<TProp, String> errorMessageFunc= );

	public IPropertyConfigBuilder<T, TProp> ThrowErrorIfValue(Func<TProp, Boolean> action, String errorMessage= );
}
```

</i>