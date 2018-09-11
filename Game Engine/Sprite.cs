using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace CPI311.GameEngine
{
    public class Sprite
    {
        public Sprite(Texture2D texture)
        {
            Texture = texture;
            Position = new Vector2(0f, 0f);
            Source = new Rectangle(0, 0, texture.Width, texture.Height);
            Color = Color.White;
            Rotation = 0f;
            Origin = new Vector2(0.5f, 0.5f);
            Scale = Vector2.One;
            Effect = SpriteEffects.None;
            Depth = 1f;
            Width = Texture.Width;
            Height = Texture.Height;
        }

        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Source { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }
        public SpriteEffects Effect { get; set; }
        public float Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void Update() { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Source, Color, Rotation, Origin, Scale, Effect, Depth);
        }
    }
}
