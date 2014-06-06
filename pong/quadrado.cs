using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
namespace pong
{
    class quadrado : GameComponent
    {
        public Texture2D textura;
        public Vector2 XY;

        public quadrado(Game principal, Texture2D textura, Vector2 XY) : base(principal)
        {   
            this.XY = XY;
            this.textura = textura;
        }
        
        public Vector2 getXY(){
            return XY;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, XY, Color.White);
        }
    }
}
