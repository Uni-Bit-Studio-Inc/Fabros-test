using RunDoorsButtons.Components;
using UnityEngine;

namespace RunDoorsButtons.Pathfinders
{
    public class RemotePathfinder : IPathfinder
    {
        public void SetPlayerMoveTarget(PlayerComponent playerComponent, Vector3 target)
        {
            //some remote logic to set move
        }
    }
}