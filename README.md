# UniversalTypeConverter

The Swiss Army Knife for type conversion in .NET

- [NuGet Package](https://www.nuget.org/packages/UniversalTypeConverter/)
- [Browse API](https://t-bruning.github.io/UniversalTypeConverter/api/index.html)
- [Supported conversions](https://t-bruning.github.io/UniversalTypeConverter/conversionoverview.htm)
- [License (MS-PL)](https://opensource.org/licenses/ms-pl.html)

Convert any type to another compatible type without worrying about which method to use.

Just write
```csharp
var result = myObj.To<T>()
```

to convert *myObj* to *T*

All imaginable types of conversions are integrated and can be configured in a variety of ways. You can even add your own conversion methods if something doesn't meet your needs. You can also use any number of converters simultaneously and configure them independently, e.g. to treat values from the database differently from values received via a Web API.

So you have the following extension methods to your hand:  

**To\<T\>()**:  
Converts the given value to the given type using the default converter. Throws an InvalidConversionException if the value is not convertible to the given type.

**IsConvertibleTo\<T\>()**:  
Determines whether the given value can be converted to the specified type using the default converter. Returns true if the given value can be converted to the specified type; otherwise, false without throwing an exception.

**As\<T\>()**:  
Converts the given value to the given type using the default converter. The result provides access to the converted value if conversion succeeded and simplifies access to default values if conversion failed, e.g.:
```csharp
var x = y.As<int>().OrDefault();	// returns 0 (the default of int) if y is not convertible to int.
```

**ToEnumerable\<T\>()**:  
Returns an iterator over the results of converting the given values to the given type.

Most extension methods provide an overload with the destination type as an parameter if using the generic version is not possible.

You are able to configure the default converter by setting the properties of UniversalTypeConverter.Options.

If you need another converter beside the default one, just create a new instance of "TypeConverter".

---------

This is a complete rewrite of version 1 of the UniversalTypeConverter. If you are interested in why I started this project and what the basic thoughts and concepts were, I recommend you to read my article on [codeproject.com](https://www.codeproject.com/Articles/248440/Universal-Type-Converter), as most of the conversion methods apply to this version as well.

**If you have already used the first version of the UniversalTypeConverter**:  
Some of the old extension methods are marked as "obsolete", but still work. I recommend replacing them with the new signatures, as the old variants will be removed at some point. However, there are also some methods and options that have been removed. If you have used them, you can expect Breaking Changes. If you are unsure: stay at version 1 on existing projects and use version 2 for new projects.

--------

Have a look at the [supported conversions](https://t-bruning.github.io/UniversalTypeConverter/conversionoverview.htm).
