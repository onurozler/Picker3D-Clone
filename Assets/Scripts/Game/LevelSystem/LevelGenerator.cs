using Game.Managers;
using Game.PickerSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.LevelSystem
{
    public class LevelGenerator : MonoBehaviour
    {
        private PickerBase _pickerBase;
        private int _levelIndex;
        
        [Inject]
        private void OnInstaller(PickerBase pickerBase)
        {
            _pickerBase = pickerBase;
            _levelIndex = 0;
        }

        public void GenerateLevel()
        {
            var levelData = AssetManager.Instance.LoadLevel(_levelIndex);
            var platformList = levelData.PlatformDatas;

        }
    }
}
