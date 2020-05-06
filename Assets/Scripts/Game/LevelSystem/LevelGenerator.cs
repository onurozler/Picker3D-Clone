using Game.Managers;
using Game.PickerSystem.Base;
using Game.PlatformSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        private PoolManager _poolManager;
        private PickerBase _pickerBase;
        private int _levelIndex;
        private Vector3 _pickerStartPosition;
        
        [Inject]
        private void OnInstaller(PickerBase pickerBase, PoolManager poolManager)
        {
            _poolManager = poolManager;
            _pickerBase = pickerBase;
            _pickerStartPosition = new Vector3(0,0.6f,2.5f);
            _levelIndex = 1;
        }

        public void GenerateLevel()
        {
            var levelData = AssetManager.Instance.LoadLevel(_levelIndex);
            var platformList = levelData.PlatformDatas;
            foreach (var platformData in platformList)
            {
                var platform = _poolManager.GetAvailablePlatform(platformData.PlatformType);
                platform.transform.position = platformData.Position;
                platform.Initialize();

                if (platform.PlatformType == PlatformType.CHECKPOINT)
                    platform.GetComponent<CheckPoint>().SetTarget(platformData.CheckPointCount);
            }
            
            _pickerBase.transform.position = _pickerStartPosition;
        }
    }
}
