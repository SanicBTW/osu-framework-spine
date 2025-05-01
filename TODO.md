# Spine for osu!framework: TODO

As mentioned in the README. There's still a couple of features missing from the stable Spine, my plan is to eventually implement them so here's the track list for it.

- [ ] Avoid having to resize the VertexBatch
- [ ] Backtrack DrawNode variables into SpineSprite
- [ ] Add support for Z offsets in the attachments
- [ ] Add support for the second tint
- [ ] Fix weird texture outline in some atlases
- [ ] Add support for texture layers in MeshBatcher
- [ ] Fix rendering issues; the animation doesn't look properly, doesn't transform properly, weird flickering, ...
- [ ] Render inside the Sprite bounds using ScreenSpaceDrawQuad
- [ ] Add the debug renderer (DebugSpineDrawNode)
- [ ] Add support for osu!framework Texture Atlases;
    
    Atlases currently render without any issue but the size and position might be incorrect inside the mesh definition

- [X] ~~Tests~~ Examples
- [X] Don't force the developer to register "Resources" or a ResourceStore to use SpineSprite

### Optional changes

- [ ] Make SpineDrawNode (and the debug version once implemented) full of virtual functions to customize the default spine rendering behaviour
