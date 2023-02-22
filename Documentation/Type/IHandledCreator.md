<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Handleds.Creators.Interfaces](../Namespace/Briefcase.Handlers.Handleds.Creators.Interfaces.md);</small>

#### <small>IHandledCreator</small>

<i>

```csharp
public interface IHandledCreator : IDisposable
{

	public IHandled StopedOn(Object value, HandledStopStageEnum stopedEnum, String message); 

	public IHandled StopedOnMapper(Object value, HandledStopStageEnum stopedEnum, String message); 

	public IHandled Successfully(Object value, Object lastValue); 
}
```

</i>


#### <small>Related items</small>

[IDisposable](IDisposable.md)