using RunDoorsButtons.Components;
using UnityEngine;

namespace RunDoorsButtons
{
    public interface IPlayerMovement
    {
        void SetPlayerMoveTarget(PlayerComponent playerComponent, Vector3 target);
    }
}