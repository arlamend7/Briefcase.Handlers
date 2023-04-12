<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations.Base.Interfaces](../Namespace/Briefcase.Handlers.Operations.Base.Interfaces.md);</small>

#### <small>IEditResultTimeLiner<T></small>

<i>

```csharp
public interface IEditResultTimeLiner<T> : IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	T ResultEntity { get; }

	public T GetResultEntity(Action<IPropertyGetter<T>> getterFunc); 

	public T GetResultEntityFor(IEnumerable<IHandledChange> changes); +2 overloads
}
```

</i>


---

#### GetResultEntityFor

<small><b>Return:</b> T</small>

<i>

```csharp
public interface IEditResultTimeLiner<T> : IEditResultOrdenableChanges<T>, IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	public T GetResultEntityFor(IEnumerable<IHandledChange> changes);

	public T GetResultEntityFor(PropertyInfo[] properties);

	public T GetResultEntityFor(String[] properties);
}
```

</i>

#### <small>Related items</small>

[IEditResultOrdenableChanges<T>](IEditResultOrdenableChanges`1.md)
[IResultAsync<IHandled>](IResultAsync`1.md)
[IEnumerable<IHandled>](IEnumerable`1.md)
[IEnumerable](IEnumerable.md)
[IDisposable](IDisposable.md)
[IEditResultChanges<T>](IEditResultChanges`1.md)