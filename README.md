# IniWrapper.ini-parser

This library extends [IniWrapper](https://github.com/Szpi/IniWrapper/) to use ini-parser library to parse ini files. Main goal is to support multiplatform.

## Quick start
Create IniWrapperFactory and invoke CreateWithIniParser method as it is shown below.

```csharp
var iniWrapperFactory = new IniWrapperFactory();
var iniWrapper = iniWrapperFactory.CreateWithIniParser(x =>
{
	x.IniFilePath = path;
});

var iniWrapperFactory = new IniWrapperFactory();
var iniWrapper = iniWrapperFactory.CreateWithIniParser(new IniSettings()
{
	IniFilePath = path
});
```