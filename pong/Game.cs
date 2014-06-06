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

    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Barra barra;
        private Bola bola;
        private Quadrado quadrado;
        private List<Quadrado> quadrados = new List<Quadrado>();

        SpriteFont bbb;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 418;
            graphics.PreferredBackBufferHeight = 300;
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            bola = new Bola(this, Content.Load<Texture2D>("bola"), new Vector2(80, 90));
            bola.velocidade = new Vector2(4, 1); // VELOCIDADE DA BOLA


            for ( int i=0; i<56; i++ )
            {
                if (i <= 16)
                {
                    quadrado = new Quadrado(this, Content.Load<Texture2D>("quadrado"), new Vector2((i + 1) * 22, 30));
                }
                else if (i <= 31)
                { 
                    quadrado = new Quadrado(this, Content.Load<Texture2D>("quadrado"), new Vector2((i - 15) * 22, 53));
                }
                else if (i <= 44)
                {
                    quadrado = new Quadrado(this, Content.Load<Texture2D>("quadrado"), new Vector2((i - 29) * 22, 76));
                }
                else 
                {
                    quadrado = new Quadrado(this, Content.Load<Texture2D>("quadrado"), new Vector2((i - 41) * 22, 99));
                }
                
                quadrados.Add(quadrado);
            }
            

            barra = new Barra(this, Content.Load<Texture2D>("barra"), new Vector2( Window.ClientBounds.Width/2-35 , 385));

            this.Components.Add(bola);
            this.Components.Add(barra);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //*/ TAH QUI CARALHOOOOOOOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            if ( bola.posicao.Y + bola.textura.Height > 290 ){
                if (bola.posicao.X >= barra.posicao.X && bola.posicao.X <= barra.posicao.X+barra.textura.Width)
                {
                    bola.velocidade.Y = -bola.velocidade.Y;
                }
            }
            
            //*/
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);


            foreach(Quadrado q in quadrados){
                q.Draw(spriteBatch);
            }       
     
            barra.Draw(spriteBatch);
            bola.Draw(spriteBatch);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
