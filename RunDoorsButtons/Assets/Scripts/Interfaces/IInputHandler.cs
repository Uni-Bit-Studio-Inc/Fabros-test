using UnityEngine;

namespace RunDoorsButtons.Inputs
{
    public interface IInputHandler
    {
        void GetInputPosition(out Vector3 pos);
    }
}