<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Configurations](../Namespace/Briefcase.Handlers.Configurations.md);</small>

#### <small>TryConvertMessage</small>

<i>

```csharp
public sealed class TryConvertMessage : MulticastDelegate, ICloneable, ISerializable
{

	///<DeclaredOn>Delegate</DeclaredOn>
	Object Target { get; }

	///<DeclaredOn>Delegate</DeclaredOn>
	MethodInfo Method { get; }

	public TryConvertMessage(Object object, IntPtr method); 

	public Boolean Invoke(Object obj, out Object result, out String errorMessage); 

	public IAsyncResult BeginInvoke(Object obj, out Object result, out String errorMessage, AsyncCallback callback, Object object); 

	public Boolean EndInvoke(out Object result, out String errorMessage, IAsyncResult __result); 

	///<DeclaredOn>MulticastDelegate</DeclaredOn>
	public Void GetObjectData(SerializationInfo info, StreamingContext context); 

	///<DeclaredOn>MulticastDelegate</DeclaredOn>
	public Boolean Equals(Object obj); 

	///<DeclaredOn>MulticastDelegate</DeclaredOn>
	public Delegate[] GetInvocationList(); 

	///<DeclaredOn>MulticastDelegate</DeclaredOn>
	public Int32 GetHashCode(); 

	///<DeclaredOn>Delegate</DeclaredOn>
	public Object Clone(); 

	///<DeclaredOn>Delegate</DeclaredOn>
	public Object DynamicInvoke(Object[] args); 
}
```

</i>


#### <small>Related items</small>

[ICloneable](ICloneable.md)
[ISerializable](ISerializable.md)
[MulticastDelegate](MulticastDelegate.md)