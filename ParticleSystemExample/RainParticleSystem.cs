﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ParticleSystemExample
{
    public class RainParticleSystem : ParticleSystem
    {
        Rectangle _source;

        public bool IsRaining { get; set; } = true;
        public RainParticleSystem(Game game, Rectangle source) : base(game, 4000)
        {
            _source = source;
        }

        protected override void InitializeConstants()
        {
            textureFilename = "drop";
            minNumParticles = 10;
            maxNumParticles = 20;
        }

        protected override void InitializeParticle(ref Particle p, Vector2 where)
        {
            p.Initialize(where, Vector2.UnitY * 260, Vector2.Zero, Color.LightSkyBlue, scale: RandomHelper.NextFloat(0.1f, 0.4f), lifetime: 3f);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(IsRaining) AddParticles(_source);

        }
    }
}
