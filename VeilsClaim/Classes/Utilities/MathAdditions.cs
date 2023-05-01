using Microsoft.Xna.Framework;
using System;

namespace VeilsClaim.Classes.Utilities
{
    public static class MathAdditions
    {
        public static Vector2 VectorFromAngle(float angle)
        {
            return new Vector2(MathF.Cos(angle), MathF.Sin(angle));
        }
        public static Vector2 RandomVector()
        {
            return RandomVector(1f);
        }
        public static Vector2 RandomVector(float length)
        {
            return RandomVector(0f, MathHelper.Tau, length);
        }
        public static Vector2 RandomVector(float minLength, float maxLength)
        {
            return RandomVector(0f, MathHelper.Tau, minLength, maxLength);
        }
        public static Vector2 RandomVector(float minAngle, float maxAngle, float length)
        {
            return RandomVector(minAngle, maxAngle, length, length);
        }
        public static Vector2 RandomVector(float minAngle, float maxAngle, float minLength, float maxLength)
        {
            float angle = Main.Random.NextSingle() * (maxAngle - minAngle);
            Vector2 vector = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
            float length = minLength;
            if (minLength != maxLength)
                length = Main.Random.NextSingle() * (maxLength - minLength) + minLength;
            return vector * length;
        }
        public static bool Probability(float delta, float chance)
        {
            return Main.Random.NextSingle() < (delta * 60f * chance);
        }
        public static float Map(float value, float in1, float in2, float out1, float out2)
        {
            return (value - in1) / (in2 - in1) * (out2 - out1) + out1;
        }
    }
}