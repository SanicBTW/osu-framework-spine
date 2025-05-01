# Spine for osu!framework

This library adds [Spine](https://github.com/EsotericSoftware/spine-runtimes/tree/4.2/spine-csharp) support for osu!framework

The code itself contains the [Spine-CS source code](https://github.com/EsotericSoftware/spine-runtimes/tree/4.2/spine-csharp/src) this is because the [NuGet library](https://www.nuget.org/packages/Spine#supportedframeworks-body-tab) was built with .NET Framework but osu!framework targets .NET 5.0^ thus giving compilation warnings about it, and we don't want that.

### WIP

This library is somewhat unfinished, I only gave the basic rendering support based off the [monogame runtime](https://github.com/EsotericSoftware/spine-runtimes/tree/4.2/spine-monogame) you will see some comments around the code that references it.

I only needed basic features for a game I'm working on and they use Spine, but I will definitely implement the missing features.

Check the [TODO]() for the pending features to be implemented.

# License

TBD but it should fall onto the [Spine Runtime License](https://esotericsoftware.com/spine-runtimes-license)