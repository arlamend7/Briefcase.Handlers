<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Interfaces](../Namespace/Briefcase.Handlers.Interfaces.md);</small>

#### <small>IEditHandlerOperation<T></small>

<i>

```csharp
public interface IEditHandlerOperation<T> : IEditResultTimeLiner<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	public IEditHandlerOperation<T> Edit(Expression<Func<T, TProp>> prop, TProp value); +2 overloads

	public IEditHandlerOperation<T> EditBy(Type type, Object request); +1 overloads
}
```

</i>


---

#### Edit

<small><b>Return:</b> IEditHandlerOperation\<T></small>

<i>

```csharp
public interface IEditHandlerOperation<T> : IEditResultTimeLiner<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	public IEditHandlerOperation<T> Edit(Action<T> request);

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
public interface IEditHandlerOperation<T> : IEditResultTimeLiner<T>, IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	public IEditHandlerOperation<T> EditBy(TRequest request);

	public IEditHandlerOperation<T> EditBy(Type type, Object request);
}
```

</i>

#### <small>Related items</small>

[IEditResultTimeLiner<T>](IEditResultTimeLiner`1.md)
[IEditResultOrdenableChanges<T>](IEditResultOrdenableChanges`1.md)
[IResultAsync<IHandled>](IResultAsync`1.md)
[IEnumerable<IHandled>](IEnumerable`1.md)
[IEnumerable](IEnumerable.md)
[IDisposable](IDisposable.md)
[IEditResultChanges<T>](IEditResultChanges`1.md)