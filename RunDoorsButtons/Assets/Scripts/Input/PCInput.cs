using RunDoorsButtons.Actors;
using UnityEngine;

namespace RunDoorsButtons.Inputs
{
    public class PCInput : IInputHandler
    {
        private RaycastHit _hit;
        private Ray _ray;

        public void GetInputPosition(out Vector3 pos)
        {
            pos = default;

            if (Input.GetMouseButtonDown(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _hit))
                {
                    if (_hit.collider.gameObject.CompareTag(GameActorsTags.Plane) || _hit.collider.gameObject.CompareTag(GameActorsTags.Button))
                    {
                        var target = _hit.point;
                        target.y = 0;
                        pos = target;
                    }
                }
            }
        }
    }
}

