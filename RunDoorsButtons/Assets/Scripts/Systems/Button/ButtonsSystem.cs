using Leopotam.EcsLite;
using RunDoorsButtons.Actors;
using RunDoorsButtons.Components;
using RunDoorsButtons.Data;
using UnityEngine;
using Zenject;

namespace RunDoorsButtons.Systems
{
    public class ButtonsSystem : IEcsInitSystem, IEcsRunSystem, IPositionCounter
    {
        public ButtonsSystem(FieldData fieldData)
        {
            _fieldData = fieldData;
        }

        private EcsWorld _world;
        private FieldData _fieldData;
        public float CountDistanceToPlayer(Vector3 playerPosition, Vector3 buttonPosition) => Vector3.Distance(playerPosition, buttonPosition);

        public void Init(EcsSystems ecsSystems)
        {
            _world = ecsSystems.GetWorld();
            var buttons = GameObject.FindGameObjectsWithTag(GameActorsTags.Button);
            int dataIndex = 0;

            foreach (var button in buttons)
            {
                var buttonEntity = _world.NewEntity();
                var buttonPool = _world.GetPool<ButtonComponent>();
                buttonPool.Add(buttonEntity);
                ref var buttonComponent = ref buttonPool.Get(buttonEntity);

                buttonComponent.Transform = button.transform;
                buttonComponent.IsPressed = false;
                buttonComponent.MeshRenderer = button.GetComponent<MeshRenderer>();

                buttonComponent.color = _fieldData.Configs[dataIndex].Color;
                buttonComponent.MeshRenderer.material = _fieldData.Configs[dataIndex].Material;
                dataIndex++;
            }
        }

        public void Run(EcsSystems ecsSystems)
        {
            var filterPlayers = _world.Filter<ButtonPresserComponent>().End();
            var filterButtons = _world.Filter<ButtonComponent>().End();
            var playerPool = _world.GetPool<ButtonPresserComponent>();
            var buttonPool = _world.GetPool<ButtonComponent>();

            foreach (var player in filterPlayers)
            {
                ref var playerComponent = ref playerPool.Get(player);

                foreach (var button in filterButtons)
                {
                    ref var buttonComponent = ref buttonPool.Get(button);

                    var isPlayerInRange = CountDistanceToPlayer(playerComponent.Transform.position, buttonComponent.Transform.position) <= _fieldData.DistanceToButton;
                    buttonComponent.IsPressed = isPlayerInRange;
                }
            }
        }
    }
}