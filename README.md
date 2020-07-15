# YouTubeFetcher.Core
This .NET Standard class library YouTubeFetcher.Core allows you to get the actual video and audio streams from YouTube.

For the decryption logic I got help from the code of the open-source project [libvideo](https://github.com/omansak/libvideo).

## Table of content
* [Installation](#installation)
* [Getting Started](#getting-started)
* [Technologies](#technologies)

## Installation
The project can be referenced via [NuGet](https://www.nuget.org/packages/YouTubeFetcher.Core/) or downloaded over GitHub.

## Getting Started
After you referenced the project to your target project you can use the library as following:

### With Dependency Injection
In Startup.cs
```C#
[...]
using YouTubeFetcher.Core.Extensions;
[...]

[...]
public void ConfigureServices(IServiceCollection services)
{
    [...]
    services.AddYouTubeService();
    [...]
}
[...]
```
In any controller or service
```C#
[...]
private readonly IYouTubeService _youTubeService;
[...]

[...]
public TestController(IYouTubeService youTubeService)
{
    [...]
    _youTubeService = youTubeService;
    [...]
}
[...]
```

### With Factory
If you cannot use dependeny injection you can simply use the built in Factory YouTubeServiceFactory.
```C#
[...]
var youTubeService = new YouTubeServiceFactory().Create();
[...]
```

## Technologies
* .NET Standard 2.1
