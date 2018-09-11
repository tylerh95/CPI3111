using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;




namespace CPI311.GameEngine
{
    public class SpriteAnimator
    {

        Sprite Sprite { get; set; }
        Vector2 Origin { get; set; }


        public SpriteAnimator(Sprite sprite, Vector2 origin)
        {
            Sprite = sprite;
            Origin = origin;
        }

        public void AnimateSpiral(float radius, float time, float speed = 1f)
        {
            float px = (float)Math.Cos(time * speed) * radius;
            float py = (float)Math.Sin(time * speed) * radius;

            Sprite.Position = new Vector2(Origin.X + px, Origin.Y + py);
            Sprite.Rotation = (float)Math.Atan2(px, -py);
        }

        public void AnimateSpiralSinusoidal(float radius, float time, float speed = 1f, float wobbling = 10f)
        {
            float sinus = (float)Math.Cos(time * wobbling);
            float scaledSinus = sinus * wobbling;
            var newSinusRadius = radius + scaledSinus;

            AnimateSpiral(newSinusRadius, time, speed);
        }
    }
}