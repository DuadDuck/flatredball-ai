﻿using FlatRedBall;
using Microsoft.Xna.Framework;
using FlatRedBallAI.AI.SteeringAgents.Helpers;

namespace FlatRedBallAI.AI.SteeringAgents.Behaviors
{
    public class WanderBehavior : IBehavior
    {
        private Vector3 mTargetPos;

        public WanderBehavior()
        {
            mTargetPos = new Vector3();
            WanderRadius = 1;
            WanderDistance = 5;
            WanderJitter = .2f;
            Weight = 1;
            Probability = 1;
            Name = "Wander";
            TargetPosition = new Vector3();
        }

        public float WanderRadius { get; set;}
        public float WanderDistance { get; set; }
        public float WanderJitter { get; set; }

        #region IBehavior Members

        public float Weight{ get; set; }
        public float Probability { get; set; }
        public string Name { get; set; }
        public Vector3 TargetPosition { get; set; }

        Vector3 IBehavior.Calculate(PositionedObject pAgent)
        {
            return SteeringHelper.Wander(pAgent, ref mTargetPos, WanderRadius, WanderDistance, WanderJitter);
        }

        #endregion
    }
}
