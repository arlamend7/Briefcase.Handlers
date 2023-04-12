<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations.Base.Interfaces](../Namespace/Briefcase.Handlers.Operations.Base.Interfaces.md);</small>

#### <small>IEditResultChanges<T></small>

<i>

```csharp
public interface IEditResultChanges<T>
{

	IEnumerable<PropertyInfo> EditedProperties { get; }

	public IEnumerable<IHandled> ForProperty(PropertyInfo property); +1 overloads

	public IHandledChange GetChangeFor(PropertyInfo property); 
}
```

</i>


---

#### ForProperty

<small><b>Return:</b> IEnumerable\<IHandled></small>

<i>

```csharp
public interface IEditResultChanges<T>
{

	public IEnumerable<IHandled> ForProperty(PropertyInfo property);

	public IEnumerable<IHandled> ForProperty(Expression<Func<T, TProp>> expression);
}
```

</i>