using Game.LevelSystem;
using Game.PickerSystem.Base;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PickerBase _pickerBase;
        [SerializeField] private LevelGenerator _levelGenerator;
        [SerializeField] private PoolManager _poolManager;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_pickerBase);
            Container.BindInstance(_levelGenerator);
            Container.BindInstance(_poolManager);
        }
    }
}