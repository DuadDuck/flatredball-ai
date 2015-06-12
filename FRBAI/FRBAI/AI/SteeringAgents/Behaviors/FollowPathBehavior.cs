using System.Collections.Generic;
using FlatRedBall;
using Microsoft.Xna.Framework;
using FlatRedBallAI.AI.SteeringAgents.Helpers;
using FlatRedBall.AI.Pathfinding;

namespace FlatRedBallAI.AI.SteeringAgents.Behaviors
{
    public class FollowPathBehavior : IBehavior
    {
        public FollowPathBehavior()
        {
            WayPointArrivedDistance = 10;
            Loop = false;
            Weight = 1;
            Probability = 1;
            MaxSpeed = 1;
            Name = "FollowPath";
            nodePath = new List<PositionedNode>();
            tempNodePath = new List<PositionedNode>();
            TargetPosition = new Vector3();
            ReversePathAfterReachingTarget = false;
        }

        public List<PositionedNode> nodePath { get; set; }
        private List<PositionedNode> tempNodePath { get; set; }
        public float WayPointArrivedDistance { get; set; }
        public bool Loop { get; set; }
        public bool ReversePathAfterReachingTarget { get; set; }
        public int MaxSpeed { get; set; }

        #region IBehavior Members

        public float Weight { get; set; }
        public float Probability { get; set; }
        public string Name { get; set; }
        public Vector3 TargetPosition { get; set; }

        Vector3 IBehavior.Calculate(PositionedObject pAgent)
        {
            //Make sure there is a path to follow
            if (nodePath != null && nodePath.Count != 0)
            {
                if (Loop == true)
                {
                    //create tempNodePath when you want to keep looping the paths
                    if (tempNodePath == null)
                    {
                        tempNodePath = new List<PositionedNode>(nodePath);
                    }
                    else if (tempNodePath.Count <= nodePath.Count)
                    {
                        tempNodePath = new List<PositionedNode>(nodePath);
                    }
                }

                PositionedNode node = nodePath[0];
                TargetPosition = node.Position;

                //Check if we have reached a waypoint
                if ((pAgent.Position - node.Position).Length() < WayPointArrivedDistance)
                {
                    nodePath.RemoveAt(0);

                    //can still improve this part by making it slows down
                    if (nodePath.Count == 0)
                    {
                        //pAgent.Velocity = Vector3.Zero;
                        return SteeringHelper.Seek(pAgent, TargetPosition, MaxSpeed, WayPointArrivedDistance);
                    }
                }
                //it hasn't reached a waypoint, so seek for destination
                else
                {
                    return SteeringHelper.Seek(pAgent, TargetPosition, MaxSpeed, WayPointArrivedDistance);
                }
            }
            else if (nodePath.Count == 0)
            {
                if (Loop == true)
                {
                    nodePath = new List<PositionedNode>(tempNodePath);

                    //reverse path direction of how it reached the target/end point
                    if (ReversePathAfterReachingTarget == true)
                    {
                        nodePath.Reverse(0, nodePath.Count);
                    }
                }
            }

            return Vector3.Zero;
        }

        #endregion
    }
}
