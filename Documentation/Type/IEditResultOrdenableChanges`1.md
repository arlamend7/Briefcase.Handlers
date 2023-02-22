<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Operations.Base.Interfaces](../Namespace/Briefcase.Handlers.Operations.Base.Interfaces.md);</small>

#### <small>IEditResultOrdenableChanges<T></small>

<i>

```csharp
public interface IEditResultOrdenableChanges<T> : IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	IEnumerable<PropertyInfo> ExecutionOrder { get; }

	IEnumerable<IHandled> Values { get; }

	IEnumerable<IHandledChange> Changes { get; }

	public Void OrderBy(Action<IPropertyGetter<T>> getterFunc); +1 overloads
}
```

</i>


---

#### OrderBy

<small><b>Return:</b> Void</small>

<i>

```csharp
public interface IEditResultOrdenableChanges<T> : IResultAsync<IHandled>, IEnumerable<IHandled>, IEnumerable, IDisposable, IEditResultChanges<T>
{

	public Void OrderBy(Action<IPropertyGetter<T>> getterFunc);

	public Void OrderBy(PropertyInfo[] properties);
}
```

</i>

#### <small>Related items</small>

[IResultAsync<IHandled>](IResultAsync`1.md)
[IEnumerable<IHandled>](IEnumerable`1.md)
[IEnumerable](IEnumerable.md)
[IDisposable](IDisposable.md)
[IEditResultChanges<T>](IEditResultChanges`1.md)