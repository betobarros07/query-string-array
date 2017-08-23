# QueryString Array Binder

[![Build](https://travis-ci.org/BetoBarros07/query_string_array.svg)](https://travis-ci.org/BetoBarros07/query_string_array)
[![Nuget Version](http://img.shields.io/nuget/v/O7.QueryStringArray.svg)](http://www.nuget.org/packages/O7.QueryStringArray)
[![Issues open](https://img.shields.io/github/issues/betobarros07/query_string_array.svg)](https://github.com/BetoBarros07/query_string_array/issues)
[![Unlicense](https://img.shields.io/badge/license-unlicense-orange.svg)](LICENSE)

QueryString Array is a library that allows you to implement an Array Binder for your QueryString Parameters in ASP.NET.

## Download Package

This is very simple, you just need download the package from nuget:

###  Command Line

* Dotnet CLI    : `dotnet add package O7.QueryStringArray`
* Visual Studio : `Install-Package O7.QueryStringArray`

### Adding reference in .csproj file

The first step that you will need to do is implement the following code in your .csproj file:

```xml
<ItemGroup>
  <PackageReference Include="O7.QueryStringArray" Version="THE_VERSION_HERE" />
</ItemGroup>
```

After that, you will execute the following command to restore the package from the nuget using Dotnet CLI:

`dotnet restore`

If you are in Visual Studio, just build the project and the IDE will do the magic!

## How to use

To use this lib you will just add this to your QueryString Parameter in your Action:

```c#
using O7.QueryStringArray;
using Microsoft.AspNetCore.Mvc;

namespace Foo
{
    [Route("api/foo-bar")]
    public class Bar : Controller
    {
        [HttpGet("contoso")]
        public IActionResult Contoso([ModelBinder(BinderType = typeof(QueryStringArrayBinder))] int[] pages)
        {
            return Ok();
        }
    }
}
```

## License

[UNLICENSE](LICENSE) © [Beto Barros](https://github.com/betobarros07)