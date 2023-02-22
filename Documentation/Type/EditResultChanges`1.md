<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations.Base](../Namespace/Briefcase.Handlers.Operations.Base.md);</small>

#### <small>EditResultChanges<T></small>

<i>

```csharp
public abstract class EditResultChanges<T> : EditResult<T>, IDisposable, IEditResultChanges<T>
{

	IEnumerable<PropertyInfo> EditedProperties { get; }

	///<DeclaredOn>EditResult<T></DeclaredOn>
	T Entity { get; set; }

	public IEnumerable<IHandled> ForProperty(Expression<Func<T, TProp>> expression); +1 overloads

	public IHandledChange GetChangeFor(PropertyInfo property); +1 overloads

	///<DeclaredOn>EditResult<T></DeclaredOn>
	public Void Dispose(); 
}
```

</i>


---

#### ForProperty

<small><b>Return:</b> IEnumerable\<IHandled></small>

<i>

```csharp
public abstract class EditResultChanges<T> : EditResult<T>, IDisposable, IEditResultChanges<T>
{

	public IEnumerable<IHandled> ForProperty(Expression<Func<T, TProp>> expression);

	public IEnumerable<IHandled> ForProperty(PropertyInfo property);
}
```

</i>

---

#### GetChangeFor

<small><b>Return:</b> IHandledChange</small>

<i>

```csharp
public abstract class EditResultChanges<T> : EditResult<T>, IDisposable, IEditResultChanges<T>
{

	public IHandledChange GetChangeFor(PropertyInfo property);

	public IHandledChange GetChangeFor(Expression<Func<T, TProp>> expression);
}
```

</i>

#### <small>Related items</small>

[IDisposable](IDisposable.md)
[IEditResultChanges<T>](IEditResultChanges`1.md)
[EditResult<T>](EditResult`1.md)