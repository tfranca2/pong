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
    class bola : GameComponent
    {
        public Texture2D textura;
        public Vector2 posicao;
        public Vector2 velocidade;

        public bola(Game principal, Texture2D textura, Vector2 posicao)
            : base(principal)
        {
            this.posicao = posicao;
            this.textura = textura;
        }

        public override void Update(GameTime gameTime)
        {
            if (posicao.X + textura.Width + velocidade.X > this.Game.Window.ClientBounds.Width)
            {
                velocidade.X = -velocidade.X;//direita
            }

            if (posicao.Y + textura.Height + velocidade.Y > this.Game.Window.ClientBounds.Height)
            {
                velocidade.Y = -velocidade.Y;//de baixo
            }
            if (posicao.X + velocidade.X < 0)
            {
                velocidade.X = -velocidade.X;//esquerda
            }
            if (posicao.Y + velocidade.Y < 0)
            {
                velocidade.Y = -velocidade.Y;//de cima
            }

            posicao += velocidade;//atualiza a posição
            base.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, posicao, Color.White);
        }
    }
}
