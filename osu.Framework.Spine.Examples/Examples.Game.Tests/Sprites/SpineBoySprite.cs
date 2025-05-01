using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Spine.Graphics;
using Spine;

namespace Examples.Game.Tests.Sprites
{
    /// <summary>
    /// The Spineboy screen shows how to queue up multiple animations via animation state,
    /// set the default mix time to smoothly transition between animations, and load a
    /// skeleton from a binary .skel file.
    /// </summary>
    public partial class SpineBoySprite : SpineSprite
    {
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore largeTextureStore)
        {
            using StreamReader atlasReader = OpenStream("Data/spineboy.atlas");
            Atlas = new Atlas(atlasReader, "Textures/", new OsuFrameworkTextureLoader(largeTextureStore));

            using StreamReader binaryReader = OpenStream("Data/spineboy-pro.skel");
            SkeletonBinary binary = new SkeletonBinary(Atlas) { Scale = 0.5F };
            SkeletonData skeletonData = binary.ReadSkeletonData(binaryReader.BaseStream);

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

            // We want 0.2 seconds of mixing time when transitioning from
            // any animation to any other animation.
            State.Data.DefaultMix = 0.2F;

            // Set the "walk" animation on track one and let it loop forever
            State.SetAnimation(0, "walk", true);

            // Queue another animation after 2 seconds to let Spineboy jump
            State.AddAnimation(0, "jump", false, 2);

            // After the jump is complete, let Spineboy walk
            State.AddAnimation(0, "run", true, 0);
        }
    }
}
