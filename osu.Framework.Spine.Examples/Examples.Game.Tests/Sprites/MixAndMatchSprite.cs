using System.IO;
using osu.Framework.Allocation;
using osu.Framework.Graphics.Textures;
using osu.Framework.Spine.Graphics;
using Spine;

namespace Examples.Game.Tests.Sprites
{
    /// <summary>
    /// The mix-and-match screen demonstrates how to create and apply a skin
    /// composed of other skins. This method can be used to create customizable
    /// avatar systems.
    /// </summary>
    public partial class MixAndMatchSprite : SpineSprite
    {
        [BackgroundDependencyLoader]
        private void load(LargeTextureStore largeTextureStore)
        {
            using StreamReader atlasReader = OpenStream("Data/mix-and-match.atlas");
            Atlas = new Atlas(atlasReader, "Textures/", new OsuFrameworkTextureLoader(largeTextureStore));

            using StreamReader jsonReader = OpenStream("Data/mix-and-match-pro.json");
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

            State.SetAnimation(0, "dance", true);

            // Create a new skin, by mixing and matching other skins
            // that fit together. Items making up the girl are individual
            // skins. Using the skin API, a new skin is created which is
            // a combination of all these individual item skins.
            var mixAndMatchSkin = new Skin("custom-girl");
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("skin-base"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("nose/short"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("eyelids/girly"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("eyes/violet"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("hair/brown"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("clothes/hoodie-orange"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("legs/pants-jeans"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("accessories/bag"));
            mixAndMatchSkin.AddSkin(Skeleton.Data.FindSkin("accessories/hat-red-yellow"));
            Skeleton.SetSkin(mixAndMatchSkin);
        }
    }

}
