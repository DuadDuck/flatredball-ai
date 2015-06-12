using System.Collections.Generic;
using FlatRedBall;
using Microsoft.Xna.Framework;
using FlatRedBallAI.AI.SteeringAgents.Behaviors;

namespace FlatRedBallAI.AI.SteeringAgents.ForceCalculations
{
    public interface IForceCalculation
    {
       Vector3 Calculate(PositionedObject pAgent, List<IBehavior> pBehaviors, float pMaxForce);
    }
}
