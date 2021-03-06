﻿using FlatRedBall;
using Microsoft.Xna.Framework;
using FlatRedBallAI.AI.SteeringAgents.Helpers;

namespace FlatRedBallAI.AI.SteeringAgents.Behaviors
{
    public class EvadeBehavior : IBehavior
    {
        public EvadeBehavior(PositionedObject pTarget)
        {
            mTarget = pTarget;
            MaxSpeed = 1;
            PanicDistance = 10;
            Weight = 1;
            Probability = 1;
            Name = "Evade";
            TargetPosition = new Vector3();
        }

        public float PanicDistance { get; set; }
        public int MaxSpeed { get; set; }

        private PositionedObject mTarget;
        public PositionedObject Target
        {
            get { return mTarget; }
            set { mTarget = value; }
        }

        #region IBehavior Members

        public float Weight{ get; set; }
        public float Probability { get; set; }
        public string Name { get; set; }
        public Vector3 TargetPosition { get; set; }

        Vector3 IBehavior.Calculate(PositionedObject pAgent)
        {
            return SteeringHelper.Evade(pAgent, mTarget, PanicDistance, MaxSpeed);
        }
        
        #endregion
    }
}
