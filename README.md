# HtmlHelper Extended #

**HtmlHelper Extended** provides several useful extension methods used in ASP.NET MVC razor scripts.


## Package Status ##

| **HtmlHelper Extended** |
|:-----------------------:|
| [![](https://img.shields.io/nuget/v/Aliencube.HtmlHelper.Extended.svg)](https://www.nuget.org/packages/Aliencube.HtmlHelper.Extended/) [![](https://img.shields.io/nuget/dt/Aliencube.HtmlHelper.Extended.svg)](https://www.nuget.org/packages/Aliencube.HtmlHelper.Extended/) |


## Build Status ##

| `master` | `dev` | `release` |
|:--------:|:-----:|:---------:|
| [![Build status](https://ci.appveyor.com/api/projects/status/fk763fdpdri4h8m8/branch/master?svg=true)](https://ci.appveyor.com/project/justinyoo/htmlhelper-extended/branch/master) | [![Build status](https://ci.appveyor.com/api/projects/status/fk763fdpdri4h8m8/branch/dev?svg=true)](https://ci.appveyor.com/project/justinyoo/htmlhelper-extended/branch/dev) | [![Build status](https://ci.appveyor.com/api/projects/status/fk763fdpdri4h8m8/branch/release?svg=true)](https://ci.appveyor.com/project/justinyoo/htmlhelper-extended/branch/release) |


## Getting Started ##

**HtmlHelper Extended** provides three basic HTML controls to be used in Razor scripts.


### `HtmlHelper.Link()` ###

`@Html.Link()` method has the following variations:

```csharp
@Html.Link("Link Text", "http://link.url");
@Html.Link("Link Text", "http://link.url", new { title = "Link Title" });
@Html.Link("Link Text", "http://link.url", new Dictionary<string, object> () { { "title", "Link Title" } });
```


### `HtmlHelper.Image()` ###

`@Html.Image()` method has the following variations:

```csharp
@Html.Image("http://image.source");
@Html.Image("http://image.source", new { alt = "Alternative Text" });
@Html.Image("http://image.source", new Dictionary<string, object>() { { "alt", "Alternative Text" } });
```


### `HtmlHelper.ImageActionLink()` ###

`@Html.ImageActionLink()` method has the following variations:

```csharp
@Html.ImageActionLink("http://image.source", "Action Method Name");
@Html.ImageActionLink("http://image.source", "Action Method Name", new { title = "Link Title" });
@Html.ImageActionLink("http://image.source", "Action Method Name", new { title = "Link Title" }, new { border = 0 });
@Html.ImageActionLink("http://image.source", "Action Method Name", new { id = 1 }, new { title = "Link Title" }, new { border = 0 });

@Html.ImageActionLink("http://image.source", "Action Method Name", "Controller Name");
@Html.ImageActionLink("http://image.source", "Action Method Name", "Controller Name", new { title = "Link Title" });
@Html.ImageActionLink("http://image.source", "Action Method Name", "Controller Name", new { title = "Link Title" }, new { border = 0 });
@Html.ImageActionLink("http://image.source", "Action Method Name", "Controller Name", new { id = 1 }, new { title = "Link Title" }, new { border = 0 });
```

And more...


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work, please send us a pull request onto our `dev` branch for review.


## License ##

**HtmlHelper Extended** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2015 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
