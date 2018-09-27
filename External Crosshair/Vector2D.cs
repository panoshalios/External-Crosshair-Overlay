using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacks
{
    public class Vector2D
    {
        public float X;
        public float Y;

        public virtual float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            }
        }

        public Vector2D(float x, float y)
        {
            X = x;
            Y = y;
        }

        public static float Distance(Vector2D vector1, Vector2D vector2)
        {
            return (vector1 - vector2).Magnitude;
        }

        public static Vector2D operator +(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector2D operator -(Vector2D vector1, Vector2D vector2)
        {
            return new Vector2D(vector1.X - vector2.Y, vector1.Y - vector2.Y);
        }
    }
}
