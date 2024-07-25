# UniversalTypeConverter

The Swiss Army Knife for type conversion in .NET

 [![Release](https://img.shields.io/github/v/release/t-bruning/UniversalTypeConverter)](https://github.com/t-bruning/UniversalTypeConverter/releases) [![NuGet Version](https://img.shields.io/nuget/v/UniversalTypeConverter)](https://www.nuget.org/packages/UniversalTypeConverter/) [![Static Badge](https://img.shields.io/badge/dependency_free-1b963c)](https://www.nuget.org/packages/UniversalTypeConverter/#dependencies-body-tab)
 [![NuGet Downloads](https://img.shields.io/nuget/dt/UniversalTypeConverter)](https://www.nuget.org/packages/UniversalTypeConverter/)

- [Supported conversions](https://t-bruning.github.io/UniversalTypeConverter/conversionoverview.htm)
- [Browse API](https://t-bruning.github.io/UniversalTypeConverter/api/index.html)
- [NuGet Package](https://www.nuget.org/packages/UniversalTypeConverter/)
- [License (MS-PL)](https://opensource.org/licenses/ms-pl.html)

Convert any type to another compatible type without worrying about which method to use.

Just write
```csharp
var result = myObj.To<T>()
```

to convert *myObj* to *T*

[All imaginable types of conversions](https://t-bruning.github.io/UniversalTypeConverter/conversionoverview.htm) are integrated and can be configured in a variety of ways. You can even add your own conversion methods if something doesn't meet your needs. You can also use any number of converters simultaneously and configure them independently, e.g. to treat values from the database differently from values received via a Web API.

So you have the following extension methods to your hand:  

**To\<T\>()**:  
Converts the given value to the given type using the default converter. Throws an _InvalidConversionException_ if the value is not convertible to the given type.

**IsConvertibleTo\<T\>()**:  
Determines whether the given value can be converted to the specified type using the default converter. Returns _true_ if the given value can be converted to the specified type; otherwise, _false_ without throwing an exception.

**As\<T\>()**:  
Converts the given value to the given type using the default converter. The result provides access to the converted value if conversion succeeded and simplifies access to default values if conversion failed, e.g.:
```csharp
var x = y.As<int>().OrDefault();	// returns 0 (the default of int) if y is not convertible to int.
```

**ToEnumerable\<T\>()**:  
Returns an iterator over the results of converting the given values to the given type.

Most extension methods provide an overload with the destination type as an parameter if using the generic version is not possible.

You are able to configure the default converter by setting the properties of _UniversalTypeConverter.Options_.

If you need another converter beside the default one, just create a new instance of "_TypeConverter_".

## Mapping
Beside the obvious conversions, there are the following extension methods:

**ToDictionary()**:  
Creates a new dictionary whose key value pairs represent all non static public values of the given source.

The other way around you can create the instance of any type from an _IDictionary\<string, object\>_ by calling:

**Create\<T\>()**:  
Creates a new instance of the given type by mapping the key value pairs of the given dictionary to constructor parameters, public properties and public fields of the given type. For success, at least on key value pair must be used as a constructor parameter, public property or public field. If the dictionary contains only one key value pair, its value is returned if it is exactly of the demanded type. Conversion is done automatically if a property does not fit to the destination type.

By using these two methods you are able to create any object from any other as long as there are some naming matches! Just use:
```csharp
var x = y.ToDictionary().Create<X>();
```

## ADO.NET
_ToDictionary()_ handles _IDataRecord_ (mostly a _DataReader_), _DataRow_ and _DataRowView_ slightly different. For these types the key value pairs of the created dictionary represent the fields. In addition to that, calling _To\<T\>()_ on any of these types will use _ToDictionary()_ and _Create\<T\>()_ behind the scene - so the following will work:
```csharp
var x = myDataRow.To<X>();
```

**ToDataTable()**:  
Works on _IEnumerable\<T\>_ and creates a _DataTable_. Each element of the  given source results in a row representing the properties of \<T\> as columns.

---------

**Notice**  
This is a complete rewrite of version 1 of the UniversalTypeConverter. If you are interested in why I started this project and what the basic thoughts and concepts were, I recommend you to read my article on [codeproject.com](https://www.codeproject.com/Articles/248440/Universal-Type-Converter), as most of the conversion methods apply to this version as well.

**If you have already used the first version of the UniversalTypeConverter**:  
Some of the old extension methods are marked as "obsolete", but still work. I recommend replacing them with the new signatures, as the old variants will be removed at some point. However, there are also some methods and options that have been removed. If you have used them, you can expect Breaking Changes. If you are unsure: stay at version 1 on existing projects and use version 2 for new projects.
