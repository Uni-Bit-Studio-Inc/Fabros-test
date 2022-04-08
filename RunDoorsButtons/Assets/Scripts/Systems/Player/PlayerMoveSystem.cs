using Leopotam.EcsLite;
using RunDoorsButtons.Components;
using UnityEngine;

namespace RunDoorsButtons.Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private IPathfinder _pathfinder;

        public PlayerMoveSystem(IPathfinder pathfinder)
        {
            _pathfinder = pathfinder;
        }

        private EcsWorld _world;
        public void Run(EcsSystems ecsSystems)
        {
            if (_world == null)
                _world = ecsSystems.GetWorld();

            var filter = _world.Filter<PlayerComponent>().Inc<PlayerInputComponent>().End();
            var playerPool = _world.GetPool<PlayerComponent>();
            var playerInputPool = _world.GetPool<PlayerInputComponent>();

            foreach (var entity in filter)
            {
                ref var playerComponent = ref playerPool.Get(entity);
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                _pathfinder.SetPlayerMoveTarget(playerComponent, playerInputComponent.TargetDestination);
            }
        }
    }
}