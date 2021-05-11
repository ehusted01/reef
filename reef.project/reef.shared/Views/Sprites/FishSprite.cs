using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using reef.shared.Utils;
using reef.shared.Config;

namespace reef.shared.Views.Sprites
{
    //Just like a normal sprite, but this one can move!
    //(and later, be tapped)
    class FishSprite : Sprite {
        public FishSprite() :
          base() {
        }

        public FishSprite(Texture2D texture) :
          this() {
            SpriteTexture = texture;
            Origin = texture.GetOrigin();
        }

        public override void Update(GameTime gameTime) {
            currentColour = SpriteColour * Opacity; // Update the current colour
            
            Vector2 newpos = new Vector2(0,0);
            Vector2 increment = new Vector2(3, 0);
            Vector2.Add(ref Position, ref increment, out newpos);
            if (newpos.X > 1300) {
                newpos.X = -200;
            }
            Position = newpos;
        }
    }
}
