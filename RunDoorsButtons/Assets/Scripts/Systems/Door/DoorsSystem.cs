using Leopotam.EcsLite;
using RunDoorsButtons.Actors;
using RunDoorsButtons.Components;
using RunDoorsButtons.Data;
using UnityEngine;

namespace RunDoorsButtons.Systems
{
    public class DoorsSystem : IEcsRunSystem, IEcsInitSystem
    {
        public DoorsSystem(FieldData fieldData)
        {
            _fieldData = fieldData;
        }

        private EcsWorld _world;
        private FieldData _fieldData;

        public void Init(EcsSystems ecsSystems)
        {
            _world = ecsSystems.GetWorld();
            var doors = GameObject.FindGameObjectsWithTag(GameActorsTags.Door);
            int dataIndex = 0;

            foreach (var door in doors)
            {
                var doorEntity = _world.NewEntity();

                var doorPool = _world.GetPool<DoorComponent>();
                doorPool.Add(doorEntity);
                ref var doorComponent = ref doorPool.Get(doorEntity);

                doorComponent.Transform = door.transform;
                doorComponent.Speed = 10f;
                doorComponent.Progress = 0;
                doorComponent.IsOpened = false;
                doorComponent.IsMoving = false;
                doorComponent.StartPosition = door.transform.position;
                doorComponent.MeshRenderer = door.GetComponent<MeshRenderer>();

                doorComponent.color = _fieldData.Configs[dataIndex].Color;
                doorComponent.MeshRenderer.material = _fieldData.Configs[dataIndex].Material;
                doorComponent.TargetPosition = new Vector3(door.transform.position.x, _fieldData.Configs[dataIndex].TargetY, door.transform.position.z);
                dataIndex++;
            }
        }

        public void Run(EcsSystems ecsSystems)
        {
            var filterButtons = _world.Filter<ButtonComponent>().End();
            var filterDoors = _world.Filter<DoorComponent>().End();
            var buttonsPool = _world.GetPool<ButtonComponent>();
            var doorsPool = _world.GetPool<DoorComponent>();

            foreach (var button in filterButtons)
            {
                ref var buttonComponent = ref buttonsPool.Get(button);

                foreach (var door in filterDoors)
                {
                    ref var doorMovementComponent = ref doorsPool.Get(door);

                    if (doorMovementComponent.color == buttonComponent.color)
                    {
                        if (!doorMovementComponent.IsOpened)
                        {
                            doorMovementComponent.IsMoving = buttonComponent.IsPressed;
                        }
                        else
                        {
                            doorMovementComponent.IsMoving = false;
                        }
                    }
                }
            }

            foreach (var entity in filterDoors)
            {
                ref var doorComponent = ref doorsPool.Get(entity);

                if (doorComponent.IsMoving)
                {
                    Mathf.Clamp01(doorComponent.Progress);
                    doorComponent.Transform.position = Vector3.Lerp(doorComponent.StartPosition, doorComponent.TargetPosition, doorComponent.Progress / _fieldData.DoorTimer);
                    doorComponent.Progress += Time.deltaTime;
                    doorComponent.IsOpened = doorComponent.Progress >= _fieldData.DoorTimer;                       
                }
            }
        }
    }
}