﻿using System;

namespace MarsRover
{
    public class Vector : Point
    {
        public Vector(Int32 x, Int32 y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X + vector2.X, vector1.Y + vector2.Y);
        }

        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return new Vector(vector1.X - vector2.X, vector1.Y - vector2.Y);
        }

        public Vector MinusRadians(Double radians)
        {
            var radianValue = Math.Atan2(Y, X);
            var result = radianValue - radians;
            return CreateAndNormalizeVectorFor(result);
        }

        public Vector PlusRadians(Double radians)
        {
            var radianValue = Math.Atan2(Y, X);
            var result = radianValue + radians;
            return CreateAndNormalizeVectorFor(result);
        }

        private Vector CreateAndNormalizeVectorFor(double result)
        {
            var diffVector = new Vector((Int32)Math.Cos(result), (Int32)Math.Sin(result));
            diffVector.Normalize();
            return diffVector;
        }

        public Vector Normalize()
        {
            var length = Length();

            if (length != 0)
                return new Vector((Int32)(X / length), (Int32)(Y / length));

            return null;
        }

        private Double Length()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public override Boolean Equals(Object other)
        {
            if (other.GetType() == typeof(Vector))
                return Equals((Vector)other);
            else
                return false;
        }

        private Boolean Equals(Vector other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override Int32 GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode() * 23;
        }
    }
}
