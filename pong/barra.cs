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
    class barra : GameComponent
    {
        public Texture2D textura;
        public Vector2 posicao;

        public barra(Game principal, Texture2D textura, Vector2 posicao)
            : base(principal)
        {
            this.posicao = posicao;
            this.textura = textura;
        }

        public override void Update(GameTime gameTime)
        {

            KeyboardState teclado = Keyboard.GetState();

            if (teclado.IsKeyDown(Keys.Left))
            {
                posicao -= 5;
            }
            if (teclado.IsKeyDown(Keys.Right))
            {
                posicao += 5;
            }

            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicao, Color.White);
        }
    }
}
