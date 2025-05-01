# Spine for osu!framework

This library adds [Spine](https://github.com/EsotericSoftware/spine-runtimes/tree/4.2/spine-csharp) support for [osu!framework](https://github.com/ppy/osu-framework)

The library itself contains the [Spine-CS source code](https://github.com/EsotericSoftware/spine-runtimes/tree/4.2/spine-csharp/src), this is because the [NuGet library](https://www.nuget.org/packages/Spine#supportedframeworks-body-tab) was built with .NET Framework but osu!framework targets .NET 5.0^ thus giving compilation warnings about it, and it's kinda annoying

### WIP
This library is somewhat unfinished, I only gave the basic rendering support based off the [monogame runtime](https://github.com/EsotericSoftware/spine-runtimes/tree/4.2/spine-monogame), you will see some comments around the code that references it.

I only needed basic features for a game I'm working on and they use Spine, but I will definitely implement the missing features.

Check the [TODO](https://github.com/SanicBTW/osu-framework-spine/blob/master/TODO.md) for the pending features to be implemented.

# License

This library uses `spine-csharp` (located as Spine in the source code) the C# Spine Runtime. To use this library, you must first agree to the following license:

* [Spine Runtimes License](https://esotericsoftware.com/spine-runtimes-license).

However the code under `osu.Framework.Spine` falls under the MIT License. See the [LICENSE](https://github.com/SanicBTW/osu-framework-spine/blob/master/License.txt) for the full text.
