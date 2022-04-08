using RunDoorsButtons.Components;
using UnityEngine;

namespace RunDoorsButtons.Pathfinders
{
    public class NavmeshPathfinder : IPathfinder
    {
        public void SetPlayerMoveTarget(PlayerComponent playerComponent, Vector3 target)
        {
            playerComponent.NavMeshAGent.SetDestination(target);
            playerComponent.NavMeshAGent.speed = playerComponent.Speed;
        }
    }
}