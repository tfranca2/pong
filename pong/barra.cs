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
    class Barra : GameComponent
    {
        public Texture2D textura;
        public Vector2 posicao;
        public int velocidade;
        public Boolean movimento;

        public Barra(Game principal, Texture2D textura, Vector2 posicao)
            : base(principal)
        {
            this.posicao = posicao;
            this.textura = textura;
            velocidade = 5;
            movimento = true;
        }

        public override void Update(GameTime gameTime)
        {
            if(movimento){
                if (posicao.X + textura.Width > this.Game.Window.ClientBounds.Width)
                {
                    posicao.X -= velocidade;
                }
                if (posicao.Y + textura.Height > this.Game.Window.ClientBounds.Height)
                {
                    posicao.Y -= velocidade;
                }
                if (posicao.X < 0)
                {
                    posicao.X += velocidade;
                }
                if (posicao.Y < 0)
                {
                    posicao.Y += velocidade;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    posicao.X -= velocidade;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    posicao.X += velocidade;
                }
            }
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicao, Color.White);
        }
    }
}
