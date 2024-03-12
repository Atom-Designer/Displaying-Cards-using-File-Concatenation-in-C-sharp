using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;

namespace War
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Card[] cardslist;
        List<Card> cards;

        SpriteFont font;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
         cardslist = new Card[52];
         String n = "";
         cards = new List<Card>();
         int j = 1;

          for (int i = 0; i < cardslist.Length; i++)
            {
              if (i == 14 || i == 27 || i == 40)
                { j = 1;}
              if (i < 13)
                {
                    j = i+1;
                    if (j < 10) n = "0" + j;
                    else n = "" + j;
                    cardslist[i] = new Card(Content.Load<Texture2D>("c" + n), "clubs", j);
                }
              else if (i < 26)
                {
                    j = i - 12;
                    if (j < 10) n = "0" + j;
                    else n = "" + j;
                    if (n.Equals("14")) n = "13";
                    cardslist[i] = new Card(Content.Load<Texture2D>("d" + n), "diamonds", j);
                }
                else if (i < 39)
                {
                    j = i - 25;
                    if (j < 10)
                        n = "0" + j;
                    else
                        n = "" + j;
                    if (n.Equals("14"))
                        n = "13";
                    cardslist[i] = new Card(Content.Load<Texture2D>("h" + n), "hearts", j);
                }
                else if (i < 52)
                {
                    j = i - 38;
                    if (j < 10)
                        n = "0" + j;
                    else
                        n = "" + j;
                    if (n.Equals("14"))
                        n = "13";
                    cardslist[i] = new Card(Content.Load<Texture2D>("s" + n), "spades", j);
                }

            }
            for (int i = 0; i < cardslist.Length; i++)
            {
                cards.Add(cardslist[i]);
            }
            cards = ShuffledCards(cards);

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SpriteFont1");
        }

        protected override void UnloadContent()
        { }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(cards[0].texture, new Rectangle(0, 200, 120, 200), Color.White);
            spriteBatch.Draw(cards[1].texture, new Rectangle(680, 200, 110, 200), Color.White);
            spriteBatch.DrawString(font,cards[0].suit, new Vector2(10, 400), Color.White);
            spriteBatch.DrawString(font, cards[1].suit, new Vector2(700, 400), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public List<T> ShuffledCards<T>(List<T> CList)
        {
            Random r = new Random();
            var shufflerslist = new List<T>(CList);

            int n = shufflerslist.Count;
            while (n > 1)
            {
                n--;
                int k = r.Next(n + 1);
                T value = shufflerslist[k];
                shufflerslist[k] = shufflerslist[n];
                shufflerslist[n] = value;
            }

            return shufflerslist;
        }

    }
}
