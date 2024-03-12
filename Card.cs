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
    public class Card
    {
        public Texture2D texture;
        public String suit;
        public int value;
        public Card(Texture2D t, String s, int v)
        {
            texture = t;
            suit = s;
            value = v;
        }
    }
}
