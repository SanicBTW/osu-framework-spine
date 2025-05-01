using Examples.Game.Tests.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace Examples.Game.Tests.Visual
{
    public partial class CelestialCircus : TestSceneSpine
    {
        private CelestialCircusSprite sprite;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(sprite = new CelestialCircusSprite { Anchor = Anchor.Centre, Origin = Anchor.Centre });
        }
    }
}
