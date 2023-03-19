using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace VeilsClaim.Classes.Objects.Tiles
{
    public class AnimatedTile : DynamicTile
    {
        public AnimatedTile()
        {
            isPlaying = true;
            isLooping = false;
            lastFrame = 0f;
            frameRate = 0.5f;
            frameChange = 1;
            currentFrame = 0;
            frames = new List<string>();
        }

        public bool isPlaying;
        public bool isLooping;
        public float lastFrame;
        public float frameRate;
        public int frameChange;
        public int currentFrame;
        public List<string> frames;

        public override void Update(float delta)
        {
            if (isPlaying)
                lastFrame += delta;

            if (lastFrame >= frameRate)
            {
                for (int i = 0; i < Math.Floor(lastFrame / frameRate); i++)
                {
                    lastFrame = 0;
                    currentFrame += frameChange;
                    if (isLooping)
                    {
                        if (currentFrame < 0)
                            currentFrame = frames.Count - currentFrame;
                        if (currentFrame > frames.Count - 1)
                            currentFrame -= frames.Count;
                    }
                    else currentFrame = Math.Clamp(currentFrame, 0, frames.Count - 1);

                    Name = frames[currentFrame];
                }
            }

            base.Update(delta);
        }
        public override void Draw(SpriteBatch spriteBatch, Point gridPosition)
        {
            base.Draw(spriteBatch, gridPosition);
        }
    }
}