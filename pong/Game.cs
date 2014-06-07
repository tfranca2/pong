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

        private Quadrado perdeu;
        private Quadrado venceu;
        private Quadrado menu;

        private int contador;
        private int QuantQuadrados = 56;

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

            bola = new Bola(this, Content.Load<Texture2D>("bola"), new Vector2(Window.ClientBounds.Width / 2 -8, 145));

            venceu = new Quadrado(this, Content.Load<Texture2D>("venceu"), new Vector2(-100, -100));
            perdeu = new Quadrado(this, Content.Load<Texture2D>("perdeu"), new Vector2(-100, -100));
            menu = new Quadrado(this, Content.Load<Texture2D>("menu"), new Vector2(0, 0));

            for ( int i=0; i<QuantQuadrados; i++ ) // CRIAÇÃO DOS QUADRADOS
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

            barra = new Barra(this, Content.Load<Texture2D>("barra"), new Vector2(Window.ClientBounds.Width / 2 - 35, 385));

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

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                menu.posicao = new Vector2(-1000, -1000);
                bola.velocidade = new Vector2(2, 3); // VELOCIDADE DA BOLA
            }

            if ( bola.posicao.Y + bola.textura.Height >= 290 ){
                if (bola.posicao.X >= barra.posicao.X && bola.posicao.X <= barra.posicao.X + barra.textura.Width )
                { 
                    // BOLA VOLTA APOS TOCAR NA BARRA
                    bola.velocidade.Y = -bola.velocidade.Y;
                }
                else {
                    // VOCE PERDEU
                    if ( bola.posicao.Y + bola.textura.Height + bola.velocidade.Y > Window.ClientBounds.Height ) { 
                        bola.velocidade = new Vector2(0,0);
                        barra.movimento = false;
                        perdeu.posicao = new Vector2(Window.ClientBounds.Width / 2 - 40, 140);
                    }
                    
                }
            }

             foreach (Quadrado quadrado in quadrados)
                {
                    if (bola.posicao.Y <= quadrado.posicao.Y + quadrado.textura.Height)
                    if(bola.posicao.X >= quadrado.posicao.X && bola.posicao.X <= quadrado.posicao.X+quadrado.textura.Width)
                    {
                        // REMOVE O QUADRADO 
                        bola.velocidade.Y = -bola.velocidade.Y;
                        quadrado.posicao = new Vector2(-100, -100);
                    }
                }

             contador = 0;
             foreach (Quadrado quadrado in quadrados)
                {
                    if (quadrado.posicao.X == -100)
                    {
                        contador++;
                        if (contador == QuantQuadrados)
                        {
                            // VOCE VENCEU
                            venceu.posicao = new Vector2(Window.ClientBounds.Width / 2 - 40, 140);
                            bola.velocidade = new Vector2(0, 0);
                        }
                    }
                }
             

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
            venceu.Draw(spriteBatch);
            perdeu.Draw(spriteBatch);
            menu.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
