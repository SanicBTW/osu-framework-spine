using Examples.Game.Tests.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace Examples.Game.Tests.Visual
{
    public partial class PhysicsCloudPot : TestSceneSpine
    {
        private CloudPotSprite sprite;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(sprite = new CloudPotSprite { Anchor = Anchor.Centre, Origin = Anchor.Centre });
        }
    }

}
