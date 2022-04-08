using Leopotam.EcsLite;
using RunDoorsButtons.Data;
using RunDoorsButtons.Inputs;
using RunDoorsButtons.Systems;
using UnityEngine;
using Zenject;

namespace RunDoorsButtons.Mono
{
    public class StartUp : MonoBehaviour
    {
        private EcsWorld ecsWorld;
        private EcsSystems initSystems;
        private EcsSystems updateSystems;
        private EcsSystems fixedUpdateSystems;

        [Inject]
        private void Construct(
                    IInputHandler _inputHandler,
                    IPathfinder _pathfinder,
                    FieldData _data)
        {
            ecsWorld = new EcsWorld();
            var doorsSystem = new DoorsSystem(_data);
            var buttonsSystem = new ButtonsSystem(_data);

            initSystems = new EcsSystems(ecsWorld)
                .Add(new PlayerInitSystem(_data))
                .Add(doorsSystem)
                .Add(buttonsSystem);

            initSystems.Init();

            updateSystems = new EcsSystems(ecsWorld)
                .Add(new PlayerInputSystem(_inputHandler))
                .Add(buttonsSystem);

            updateSystems.Init();

            fixedUpdateSystems = new EcsSystems(ecsWorld)
                .Add(new PlayerMoveSystem(_pathfinder))
                .Add(doorsSystem);

            fixedUpdateSystems.Init();
        }

        private void Update()
        {
            updateSystems.Run();
        }

        private void FixedUpdate()
        {
            fixedUpdateSystems.Run();
        }

        private void OnDestroy()
        {
            initSystems.Destroy();
            updateSystems.Destroy();
            fixedUpdateSystems.Destroy();
            ecsWorld.Destroy();
        }
    }
}