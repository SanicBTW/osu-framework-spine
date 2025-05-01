using Examples.Game.Tests.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace Examples.Game.Tests.Visual
{
    public partial class SpineBoy : TestSceneSpine
    {
        private SpineBoySprite sprite;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(sprite = new SpineBoySprite { Anchor = Anchor.Centre, Origin = Anchor.Centre });
        }
    }
}
