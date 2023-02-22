<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Handleds.Creators](../Namespace/Briefcase.Handlers.Handleds.Creators.md);</small>

#### <small>HandledCreator</small>

<i>

```csharp
public class HandledCreator : IHandledCreator, IDisposable
{

	Type MappedType { get; }

	PropertyInfo MappedProperty { get; }

	PropertyInfo Property { get; }

	Object Value { get; }

	public static IHandledCreator Instanciate(PropertyInfo property, Object value); +1 overloads

	public IHandled StopedOn(Object value, HandledStopStageEnum stopedEnum, String message); 

	public IHandled StopedOnMapper(Object value, HandledStopStageEnum stopedEnum, String message); 

	public IHandled Successfully(Object value, Object lastValue); 

	public Void Dispose(); 

	public IHandled CreateAndDispose(Func<IHandled> create); 
}
```

</i>


---

#### Instanciate

<small><b>Return:</b> IHandledCreator</small>

<i>

```csharp
public class HandledCreator : IHandledCreator, IDisposable
{

	public static IHandledCreator Instanciate(PropertyInfo property, Object value);

	public static IHandledCreator Instanciate(PropertyMapperConfiguration property, Object value);
}
```

</i>

#### <small>Related items</small>

[IHandledCreator](IHandledCreator.md)
[IDisposable](IDisposable.md)