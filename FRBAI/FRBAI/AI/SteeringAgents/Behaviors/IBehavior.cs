﻿using FlatRedBall;
using Microsoft.Xna.Framework;

namespace FlatRedBallAI.AI.SteeringAgents.Behaviors
{
    /// <summary>
    /// Interface for behaviors for a steering agent.
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Weight behavior should be applied.  Between 0 and 1.
        /// </summary>
        float Weight { get; set; }

        /// <summary>
        /// Probability behavior should be applied.  Between 0 and 1.
        /// </summary>
        float Probability { get; set; }

        /// <summary>
        /// Give user ability to pick a certain behavior from Behavior List
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Target position that entity is seeking/targeting
        /// </summary>
        Vector3 TargetPosition { get; set; }

        /// <summary>
        /// Calculates force to apply.
        /// </summary>
        /// <param name="pAgent">Source Agent</param>
        /// <returns>Force to apply to source agent.</returns>
        Vector3 Calculate(PositionedObject pAgent);

    }
}
