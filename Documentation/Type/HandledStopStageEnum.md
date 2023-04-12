<h4 style='color: gray;margin:0; padding:0;'> [Briefcase.Handlers, Version=0.1.2.0, Culture=neutral, PublicKeyToken=null]</h4>

#### <small>namespace [Briefcase.Handlers.Handleds.Enums](../Namespace/Briefcase.Handlers.Handleds.Enums.md);</small>

#### <small>HandledStopStageEnum</small>

<i>

```csharp
public enum HandledStopStageEnum : Enum, IComparable, IFormattable, IConvertible
{

	Int32 value__;

	HandledStopStageEnum IgnoreOnMapping;

	HandledStopStageEnum IgnoreAfterConvert;

	HandledStopStageEnum Convert;

	HandledStopStageEnum IgnoreBeforeConvert;

	HandledStopStageEnum IgnoreAfterSet;

	HandledStopStageEnum Validations;

	HandledStopStageEnum Format;

	HandledStopStageEnum SetValue;

	///<DeclaredOn>Enum</DeclaredOn>
	public Boolean Equals(Object obj); 

	///<DeclaredOn>Enum</DeclaredOn>
	public Boolean HasFlag(Enum flag); 

	///<DeclaredOn>Enum</DeclaredOn>
	public Int32 GetHashCode(); 

	///<DeclaredOn>Enum</DeclaredOn>
	public String ToString(); +3 overloads

	///<DeclaredOn>Enum</DeclaredOn>
	public Int32 CompareTo(Object target); 

	///<DeclaredOn>Enum</DeclaredOn>
	public TypeCode GetTypeCode(); 
}
```

</i>


---

#### ToString

<small><b>Return:</b> String</small>

Declared on: Enum

<i>

```csharp
public enum HandledStopStageEnum : Enum, IComparable, IFormattable, IConvertible
{

	///<DeclaredOn>Enum</DeclaredOn>
	public String ToString();

	///<DeclaredOn>Enum</DeclaredOn>
	public String ToString(String format);

	///<DeclaredOn>Enum</DeclaredOn>
	public String ToString(IFormatProvider provider);

	///<DeclaredOn>Enum</DeclaredOn>
	public String ToString(String format, IFormatProvider provider);
}
```

</i>

#### <small>Related items</small>

[IComparable](IComparable.md)
[IFormattable](IFormattable.md)
[IConvertible](IConvertible.md)
[Enum](Enum.md)