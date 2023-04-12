<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations.Base](../Namespace/Briefcase.Handlers.Operations.Base.md);</small>

#### <small>EditOperation<T></small>

<i>

```csharp
public abstract class EditOperation<T> : EditResultTimeLiner<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>
{

	///<DeclaredOn>EditResultTimeLiner<T></DeclaredOn>
	T ResultEntity { get; }

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	IEnumerable<IHandled> Values { get; }

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	IEnumerable<IHandledChange> Changes { get; }

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	Int32 ExecutedLength { get; }

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	Int32 NotExecutedLength { get; }

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	Int32 ManuallyValuesAdded { get; }

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	IEnumerable<PropertyInfo> ExecutionOrder { get; }

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	IEnumerable<PropertyInfo> EditedProperties { get; }

	///<DeclaredOn>EditResult<T></DeclaredOn>
	T Entity { get; set; }

	public EditOperation`1(EditHandlerConfiguration editHandler, T entity); 

	///<DeclaredOn>EditResultTimeLiner<T></DeclaredOn>
	public T GetResultEntityFor(String[] properties); +2 overloads

	///<DeclaredOn>EditResultTimeLiner<T></DeclaredOn>
	public T GetResultEntity(Action<IPropertyGetter<T>> getterFunc); 

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	public Void OrderBy(Action<IPropertyGetter<T>> getterFunc); +1 overloads

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	public IEnumerator<IHandled> GetEnumerator(); 

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	public Void Dispose(); +1 overloads

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IEnumerable<IHandled> ForProperty(Expression<Func<T, TProp>> expression); +1 overloads

	///<DeclaredOn>EditResultChanges<T></DeclaredOn>
	public IHandledChange GetChangeFor(PropertyInfo property); +1 overloads
}
```

</i>


---

#### GetResultEntityFor

<small><b>Return:</b> T</small>

Declared on: EditResultTimeLiner<T>

<i>

```csharp
public abstract class EditOperation<T> : EditResultTimeLiner<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>
{

	///<DeclaredOn>EditResultTimeLiner<T></DeclaredOn>
	public T GetResultEntityFor(String[] properties);

	///<DeclaredOn>EditResultTimeLiner<T></DeclaredOn>
	public T GetResultEntityFor(PropertyInfo[] properties);

	///<DeclaredOn>EditResultTimeLiner<T></DeclaredOn>
	public T GetResultEntityFor(IEnumerable<IHandledChange> changes);
}
```

</i>

---

#### OrderBy

<small><b>Return:</b> Void</small>

Declared on: EditResultOrdenableChanges<T>

<i>

```csharp
public abstract class EditOperation<T> : EditResultTimeLiner<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>
{

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	public Void OrderBy(Action<IPropertyGetter<T>> getterFunc);

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
	public Void OrderBy(PropertyInfo[] properties);
}
```

</i>

---

#### Dispose

<small><b>Return:</b> Void</small>

Declared on: EditResultOrdenableChanges<T>

<i>

```csharp
public abstract class EditOperation<T> : EditResultTimeLiner<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>
{

	///<DeclaredOn>EditResultOrdenableChanges<T></DeclaredOn>
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
public abstract class EditOperation<T> : EditResultTimeLiner<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>
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
public abstract class EditOperation<T> : EditResultTimeLiner<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>
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
[IEditResultTimeLiner<T>](IEditResultTimeLiner`1.md)
[EditResultTimeLiner<T>](EditResultTimeLiner`1.md)