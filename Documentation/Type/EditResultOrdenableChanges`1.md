<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations.Base](../Namespace/Briefcase.Handlers.Operations.Base.md);</small>

#### <small>EditResultOrdenableChanges<T></small>

<i>

```csharp
public abstract class EditResultOrdenableChanges<T> : EditResultChanges<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable
{

	IEnumerable<IHandled> Values { get; }

	IEnumerable<IHandledChange> Changes { get; }

	Int32 ExecutedLength { get; }

	Int32 NotExecutedLength { get; }

	Int32 ManuallyValuesAdded { get; }

	IEnumerable<PropertyInfo> ExecutionOrder { get; }

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	IEnumerable<PropertyInfo> EditedProperties { get; }

	///<DeclaredOn>EditResult<T></DeclaredOn>
	T Entity { get; set; }

	public EditResultOrdenableChanges`1(T entity); 

	public Void OrderBy(Action<IPropertyGetter<T>> getterFunc); +1 overloads

	public IEnumerator<IHandled> GetEnumerator(); 

	public Void Dispose(); +1 overloads

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IEnumerable<IHandled> ForProperty(Expression<Func<T, TProp>> expression); +1 overloads

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IHandledChange GetChangeFor(PropertyInfo property); +1 overloads
}
```

</i>


---

#### OrderBy

<small><b>Return:</b> Void</small>

<i>

```csharp
public abstract class EditResultOrdenableChanges<T> : EditResultChanges<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable
{

	public Void OrderBy(Action<IPropertyGetter<T>> getterFunc);

	public Void OrderBy(PropertyInfo[] properties);
}
```

</i>

---

#### Dispose

<small><b>Return:</b> Void</small>

<i>

```csharp
public abstract class EditResultOrdenableChanges<T> : EditResultChanges<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable
{

	public Void Dispose();

	///<DeclaredOn>EditResult<T></DeclaredOn>
	public Void Dispose();
}
```

</i>

---

#### ForProperty

<small><b>Return:</b> IEnumerable\<IHandled></small>

Declared on: EditResultChanges<T>

<i>

```csharp
public abstract class EditResultOrdenableChanges<T> : EditResultChanges<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable
{

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IEnumerable<IHandled> ForProperty(Expression<Func<T, TProp>> expression);

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IEnumerable<IHandled> ForProperty(PropertyInfo property);
}
```

</i>

---

#### GetChangeFor

<small><b>Return:</b> IHandledChange</small>

Declared on: EditResultChanges<T>

<i>

```csharp
public abstract class EditResultOrdenableChanges<T> : EditResultChanges<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable
{

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IHandledChange GetChangeFor(PropertyInfo property);

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IHandledChange GetChangeFor(Expression<Func<T, TProp>> expression);
}
```

</i>

#### <small>Related items</small>

[IDisposable](IDisposable.md)
[IEditResultChanges<T>](IEditResultChanges`1.md)
[IEditResultOrdenableChanges<T>](IEditResultOrdenableChanges`1.md)
[IResultAsync<IHandled>](IResultAsync`1.md)
[IEnumerable<IHandled>](IEnumerable`1.md)
[IEnumerable](IEnumerable.md)
[EditResultChanges<T>](EditResultChanges`1.md)