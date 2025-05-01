using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Spine.Graphics;
using Spine;

namespace Examples.Game.Tests.Sprites
{
    public partial class CelestialCircusSprite : SpineSprite
    {
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore largeTextureStore)
        {
            using StreamReader atlasReader = OpenStream("Data/celestial-circus.atlas");
            Atlas = new Atlas(atlasReader, "Textures/", new OsuFrameworkTextureLoader(largeTextureStore));

            using StreamReader jsonReader = OpenStream("Data/celestial-circus-pro.json");
            SkeletonJson json = new SkeletonJson(Atlas) { Scale = 0.2F };
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
            Skeleton.Y = DrawHeight * 2F / 3F;

            State.SetAnimation(0, "swing", true);
            State.SetAnimation(1, "eyeblink", true);
        }
    }
}
