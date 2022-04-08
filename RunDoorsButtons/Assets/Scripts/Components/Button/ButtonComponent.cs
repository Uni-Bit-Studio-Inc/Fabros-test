using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunDoorsButtons.Components
{
    public struct ButtonComponent
    {
        public Transform Transform;
        public bool IsPressed;
        public Color color;
        public MeshRenderer MeshRenderer;
    }
}