using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunDoorsButtons.Components
{
    public struct DoorComponent
    {
        public Transform Transform;

        public float Speed;
        public float Progress;

        public bool IsOpened;
        public bool IsMoving;

        public Vector3 StartPosition;
        public Vector3 TargetPosition;

        public Color color;
        public MeshRenderer MeshRenderer;
    }
}