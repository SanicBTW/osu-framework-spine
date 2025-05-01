using Examples.Resources;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.IO.Stores;
using osuTK;

namespace Examples.Game.Tests
{
    public partial class TestGame : osu.Framework.Game
    {
        protected override Container<Drawable> Content { get; }
        private DependencyContainer gameDependencies;

        protected TestGame()
        {
            // Ensure game and tests scale with window size and screen DPI.
            base.Content.Add(Content = new DrawSizePreservingFillContainer
            {
                // You may want to change TargetDrawSize to your "default" resolution, which will decide how things scale and position when using absolute coordinates.
                TargetDrawSize = new Vector2(1366, 768)
            });
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Resources.AddStore(new DllResourceStore(ExamplesResources.ResourceAssembly));

            // For some atlases, its recommended to use LargeTextureStore. e.g: mipmapping, incorrect positioning due to the atlas scale adjust, etc
            IResourceStore<TextureUpload> texUpload = Host.CreateTextureLoaderStore(Resources);
            LargeTextureStore largeTs = new(Host.Renderer, texUpload);
            largeTs.AddTextureSource(texUpload);
            gameDependencies.CacheAs(largeTs);
        }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            gameDependencies = new DependencyContainer(base.CreateChildDependencies(parent));
    }
}
