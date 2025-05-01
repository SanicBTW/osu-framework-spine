using Examples.Game.Tests.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace Examples.Game.Tests.Visual
{
    public partial class Raptor : TestSceneSpine
    {
        private RaptorSprite sprite;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(sprite = new RaptorSprite { Anchor = Anchor.Centre, Origin = Anchor.Centre });
        }
    }

}
