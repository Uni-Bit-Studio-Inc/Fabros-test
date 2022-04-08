using RunDoorsButtons.Inputs;
using Zenject;

namespace RunDoorsButtons.Zenject
{
    public class InputInstaller : MonoInstaller<InputInstaller>
    {
        public override void InstallBindings()
        {
#if UNITY_STANDALONE
            Container.Bind<IInputHandler>().To<PCInput>().AsSingle().NonLazy();
#else
            Container.Bind<IInputHandler>().To<TouchInput>().AsSingle().NonLazy();
#endif
        }
    }
}