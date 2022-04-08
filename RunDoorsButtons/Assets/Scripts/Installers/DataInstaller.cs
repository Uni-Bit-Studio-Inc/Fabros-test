using RunDoorsButtons.Data;
using UnityEngine;
using Zenject;

namespace RunDoorsButtons.Zenject
{
    public class DataInstaller : MonoInstaller<DataInstaller>
    {
        [SerializeField] private FieldData _fieldData;
 
        public override void InstallBindings()
        {
            Container.Bind<FieldData>().FromInstance(_fieldData).AsSingle().NonLazy();
        }
    }
}