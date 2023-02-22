<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations](../Namespace/Briefcase.Handlers.Operations.md);</small>

#### <small>EditHandlerOperation<T></small>

<i>

```csharp
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
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

	public EditHandlerOperation`1(EditHandlerConfiguration editHandler, T entity); 

	public IEditHandlerOperation<T> Edit(Expression<Func<T, TProp>> prop, TProp value); +2 overloads

	public IEditHandlerOperation<T> EditBy(TRequest request); +1 overloads

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

#### Edit

<small><b>Return:</b> IEditHandlerOperation\<T></small>

<i>

```csharp
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
{

	public IEditHandlerOperation<T> Edit(Action<T> requestFunc);

	public IEditHandlerOperation<T> Edit(Expression<Func<T, TProp>> prop, TProp value);

	public IEditHandlerOperation<T> Edit(String prop, Object value);
}
```

</i>

---

#### EditBy

<small><b>Return:</b> IEditHandlerOperation\<T></small>

<i>

```csharp
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
{

	public IEditHandlerOperation<T> EditBy(TRequest request);

	public IEditHandlerOperation<T> EditBy(Type type, Object request);
}
```

</i>

---

#### GetResultEntityFor

<small><b>Return:</b> T</small>

Declared on: EditResultTimeLiner<T>

<i>

```csharp
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
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
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
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
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
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
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
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
public class EditHandlerOperation<T> : EditOperation<T>, IDisposable, IEditResultChanges<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IEditResultTimeLiner<T>, IEditHandlerOperation<T>
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
[IEditHandlerOperation<T>](IEditHandlerOperation`1.md)
[EditOperation<T>](EditOperation`1.md)