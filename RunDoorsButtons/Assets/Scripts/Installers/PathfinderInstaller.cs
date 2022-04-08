using RunDoorsButtons.Pathfinders;
using Zenject;

namespace RunDoorsButtons.Zenject
{
    public class PathfinderInstaller : MonoInstaller<PathfinderInstaller>
    {
        public override void InstallBindings()
        {
#if PROTOTYPE_REMOTE
            Container.Bind<IPathfinder>().To<NavmeshPathfinder>().AsSingle().NonLazy();
#endif
            //use RemotePathfinder for another pathfinder logic
        }
    }
}