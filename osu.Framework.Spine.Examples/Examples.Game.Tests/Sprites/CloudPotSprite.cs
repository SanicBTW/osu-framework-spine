using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Input.Events;
using osu.Framework.Spine.Graphics;
using osuTK;
using Spine;

namespace Examples.Game.Tests.Sprites
{
    /// <summary>
    /// The physics screen Cloud Pot demonstrates Physics Constraints introduced in Spine 4.2
    /// using the cloud-pot skeleton.
    /// </summary>
    public partial class CloudPotSprite : SpineSprite
    {
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore largeTextureStore)
        {
            using StreamReader atlasReader = OpenStream("Data/cloud-pot.atlas");
            Atlas = new Atlas(atlasReader, "Textures/", new OsuFrameworkTextureLoader(largeTextureStore));

            using StreamReader binaryReader = OpenStream("Data/cloud-pot.skel");
            SkeletonBinary binary = new SkeletonBinary(Atlas) { Scale = 0.15F };
            SkeletonData skeletonData = binary.ReadSkeletonData(binaryReader.BaseStream);

            Skeleton = new Skeleton(skeletonData);
            AnimationStateData stateData = new AnimationStateData(Skeleton.Data);
            State = new AnimationState(stateData);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            Skeleton.X = DrawWidth / 2;
            Skeleton.Y = DrawHeight * 2F / 3F;

            State.SetAnimation(0, "playing-in-the-rain", true);
        }

        protected override bool OnMouseMove(MouseMoveEvent e)
        {
            // Seems centered enough
            Skeleton.X = e.MousePosition.X;
            Skeleton.Y = e.MousePosition.Y;

            return true;
        }
    }

}
