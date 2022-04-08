using Leopotam.EcsLite;
using RunDoorsButtons.Components;
using RunDoorsButtons.Inputs;
using UnityEngine;

namespace RunDoorsButtons.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        public PlayerInputSystem(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        private EcsWorld _world;
        private IInputHandler _inputHandler;

        public void Run(EcsSystems ecsSystems)
        {
            if (_world == null)
                _world = ecsSystems.GetWorld();

            var filter = _world.Filter<PlayerInputComponent>().End();
            var playerInputPool = _world.GetPool<PlayerInputComponent>();

            foreach (var entity in filter)
            {
                ref var playerInputComponent = ref playerInputPool.Get(entity);

                _inputHandler.GetInputPosition(out Vector3 pos);
                if (pos != default)
                    playerInputComponent.TargetDestination = pos;
            }
        }
    }
}