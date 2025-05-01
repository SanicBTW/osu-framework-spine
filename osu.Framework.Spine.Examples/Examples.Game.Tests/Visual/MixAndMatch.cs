using Examples.Game.Tests.Sprites;
using osu.Framework.Allocation;
using osu.Framework.Graphics;

namespace Examples.Game.Tests.Visual
{

    public partial class MixAndMatch : TestSceneSpine
    {
        private MixAndMatchSprite sprite;

        [BackgroundDependencyLoader]
        private void load()
        {
            Add(sprite = new MixAndMatchSprite { Anchor = Anchor.Centre, Origin = Anchor.Centre});
        }
    }

}
