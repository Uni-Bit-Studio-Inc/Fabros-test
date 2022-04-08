using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunDoorsButtons
{
    public interface IPositionCounter
    {
        float CountDistanceToPlayer(Vector3 playerPosition, Vector3 buttonPosition);
    }
}