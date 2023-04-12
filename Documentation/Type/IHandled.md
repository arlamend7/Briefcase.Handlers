<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Handleds.Interfaces](../Namespace/Briefcase.Handlers.Handleds.Interfaces.md);</small>

#### <small>IHandled</small>

<i>

```csharp
public interface IHandled
{

	PropertyInfo Property { get; }

	Object OriginalValue { get; }

	Object Value { get; }

	HandledStopStageEnum StopedStage { get; }

	Boolean IsIgnore { get; }

	Boolean IsError { get; }

	Boolean ChangedProperty { get; }

	Boolean IsFromMapper { get; }
}
```

</i>
