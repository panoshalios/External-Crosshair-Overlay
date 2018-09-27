using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacks
{
    class Vector3D : Vector2D
    {
        public float Z;

        /// <summary>
        /// Returns the magnitude of the vector.
        /// </summary>
        public override float Magnitude
        {
            get
            {
                return (float)Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
            }
        }

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="x">width</param>
        /// <param name="y">depth</param>
        /// <param name="z">height</param>
        public Vector3D(float x, float y, float z) : base(x, y)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Returns the distance between the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static float Distance(Vector3D vector1, Vector3D vector2)
        {
            return (vector1 - vector2).Magnitude;
        }

        /// <summary>
        /// Returns the dot product (scalar product) of the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static float DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return (vector1.X * vector2.X) + (vector1.Y * vector2.Y) + (vector1.Z * vector2.Z);
        }
        
        /// <summary>
        /// Returns a boolean value to indicate if the two vectors are perpendicular to each other.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool Perpendicular(Vector3D vector1, Vector3D vector2)
        {
            if (DotProduct(vector1, vector2) == 0.0f)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Returns a boolean value to indicate if the two vectors are parallel to each other.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static bool Parallel(Vector3D vector1, Vector3D vector2)
        {
            Vector3D ratio = vector1 / vector2;
            float[] ratioArray = { ratio.X, ratio.Y, ratio.Z };
            return ratioArray.All(x => x == ratio.X);
        }

        /// <summary>
        /// Returns the angle between the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static float Angle(Vector3D vector1, Vector3D vector2)
        {
            return (float)(Math.Acos(DotProduct(vector1, vector2) / (vector1.Magnitude * vector2.Magnitude)) * 180 / Math.PI);
        }

        /// <summary>
        /// Returns the x-angle between the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static float AngleX(Vector3D vector1, Vector3D vector2)
        {
            Vector3D deltaVec = vector1 - vector2;
            return (float)(Math.Atan(deltaVec.Y/ deltaVec.X) * 180 / Math.PI);
        }

        /// <summary>
        /// Returns the y-angle between the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static float AngleY(Vector3D vector1, Vector3D vector2)
        {
            Vector3D deltaVec = vector1 - vector2;
            return (float)(Math.Asin(deltaVec.Z / deltaVec.Magnitude) * 180 / Math.PI);
        }

        /// <summary>
        /// Adds the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X + vector2.X, vector1.Y + vector2.Y, vector1.Z + vector2.Z);
        }

        /// <summary>
        /// Subtracts the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X - vector2.X, vector1.Y - vector2.Y, vector1.Z - vector2.Z);
        }

        /// <summary>
        /// Devides the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector3D operator /(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X / vector2.X, vector1.Y / vector2.Y, vector1.Z / vector2.Z);
        }

        /// <summary>
        /// Multiplies the two vectors.
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public static Vector3D operator *(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X * vector2.X, vector1.Y * vector2.Y, vector1.Z * vector2.Z);
        }
    }
}
