using Leopotam.EcsLite;
using RunDoorsButtons.Actors;
using RunDoorsButtons.Components;
using RunDoorsButtons.Data;
using UnityEngine;
using UnityEngine.AI;

namespace RunDoorsButtons.Systems
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        public PlayerInitSystem(FieldData fieldData)
        {
            _fieldData = fieldData;
        }

        private FieldData _fieldData;

        public void Init(EcsSystems ecsSystems)
        {
            var ecsWorld = ecsSystems.GetWorld();

            var playerEntity = ecsWorld.NewEntity();

            var playerPool = ecsWorld.GetPool<PlayerComponent>();
            playerPool.Add(playerEntity);
            ref var playerComponent = ref playerPool.Get(playerEntity);

            var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
            playerInputPool.Add(playerEntity);
            ref var playerInputComponent = ref playerInputPool.Get(playerEntity);

            var buttonPresserPool = ecsWorld.GetPool<ButtonPresserComponent>();
            buttonPresserPool.Add(playerEntity);
            ref var buttonPresserComponent = ref buttonPresserPool.Get(playerEntity);

            var playerGO = GameObject.FindGameObjectWithTag(GameActorsTags.Player);
            playerComponent.Speed = _fieldData.PlayerSpeed;
            buttonPresserComponent.Transform = playerGO.transform;
            playerComponent.NavMeshAGent = playerGO.GetComponent<NavMeshAgent>();
        }
    }
}