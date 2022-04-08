using RunDoorsButtons.Components;
using UnityEngine;

namespace RunDoorsButtons
{
    public interface IPathfinder
    {
        void SetPlayerMoveTarget(PlayerComponent playerComponent, Vector3 target);
    }
}