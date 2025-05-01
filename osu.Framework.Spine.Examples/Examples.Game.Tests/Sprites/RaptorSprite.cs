using System.IO;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Spine.Graphics;
using Spine;

namespace Examples.Game.Tests.Sprites
{
    /// <summary>
    /// The Raptor sprite shows basic loading of a Spine skeleton
    /// </summary>
    public partial class RaptorSprite : SpineSprite
    {
        // Gather the necessary texture store through DPI (BDL)
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore largeTextureStore)
        {
            using StreamReader atlasReader = OpenStream("Data/raptor.atlas");
            Atlas = new Atlas(atlasReader, "Textures/", new OsuFrameworkTextureLoader(largeTextureStore));

            using StreamReader jsonReader = OpenStream("Data/raptor-pro.json");
            SkeletonJson json = new SkeletonJson(Atlas) { Scale = 0.5F };
            SkeletonData skeletonData = json.ReadSkeletonData(jsonReader);

            Skeleton = new Skeleton(skeletonData);
            AnimationStateData stateData = new AnimationStateData(Skeleton.Data);
            State = new AnimationState(stateData);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            // Position the skeleton to the center of the sprite bounds (screen)
            Skeleton.X = DrawWidth / 2;
            Skeleton.Y = DrawHeight;

            State.SetAnimation(0, "walk", true);
        }
    }

}
