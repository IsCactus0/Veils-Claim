using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using VeilsClaim.Classes.Managers;
using VeilsClaim.Classes.Objects.Entities;
using VeilsClaim.Classes.Objects.Particles;

namespace VeilsClaim.Classes.Objects.Effects
{
    public class Overdrive : EntityEffect
    {
        public Overdrive()
        {
            MaxTime = 4f;
            Strength = 3f;
        }

        public float Strength;
        protected Color oldThrustStartColour;
        protected Color oldThrustEndColour;
        protected Color oldThrustSparkStartColour;
        protected Color oldThrustSparkEndColour;

        public override void Remove(Entity target)  
        {
            ((Vehicle)target).ThrustStrength /= Strength;
            ((Vehicle)target).ThrustStartColour = oldThrustStartColour;
            ((Vehicle)target).ThrustEndColour = oldThrustEndColour;
            ((Vehicle)target).ThrustSparkStartColour = oldThrustSparkStartColour;
            ((Vehicle)target).ThrustSparkEndColour = oldThrustSparkEndColour;

            base.Remove(target);
        }
        public override void Update(float delta, Entity target)
        {
            if (target is not Vehicle)
                return;

            if (timeActive == 0f)
            {
                ((Vehicle)target).ThrustStrength *= Strength;
                oldThrustStartColour = ((Vehicle)target).ThrustStartColour;
                oldThrustEndColour = ((Vehicle)target).ThrustEndColour;
                oldThrustSparkStartColour = ((Vehicle)target).ThrustSparkStartColour;
                oldThrustSparkEndColour = ((Vehicle)target).ThrustSparkEndColour;
            }

            if (((Vehicle)target).Thrust != 0f)
            {
                Vector2 dir = new Vector2(MathF.Cos(target.Rotation), MathF.Sin(target.Rotation));

                ParticleManager.particles.Add(new SparkParticle()
                {
                    Position = target.Position - dir * 5f,
                    Force = -target.Force,
                    Size = 5f,
                    StartSize = 5f,
                    EndSize = 15f,
                    SparkSize = 5f,
                    SparkStartSize = 5f,
                    SparkEndSize = 2.5f,
                    Colour = Color.Crimson,
                    StartColour = Color.Crimson,
                    EndColour = Color.DarkMagenta,
                    SparkColour = Color.LightCoral,
                    SparkStartColour = Color.LightCoral,
                    SparkEndColour = Color.SlateBlue,
                    Friction = 0.1f,
                    Mass = 0.01f,
                    WindStrength = 4f,
                    MaxLifespan = 0.5f + Main.Random.NextSingle() / 5f,
                });
            }

            base.Update(delta, target);
        }
        public override void Draw(SpriteBatch spriteBatch, Entity target)
        {
            
        }
    }
}