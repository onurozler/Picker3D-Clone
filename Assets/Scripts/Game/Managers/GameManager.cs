using System;
using Game.LevelSystem;
using Game.PickerSystem.Base;
using UnityEngine;
using Zenject;

namespace Game.Managers
{
    public class GameManager : MonoBehaviour
    {
        private LevelGenerator _levelGenerator;
        private PickerBase _pickerBase;
        
        [Inject]
        private void OnInstaller(LevelGenerator levelGenerator, PickerBase pickerBase)
        {
            _levelGenerator = levelGenerator;
            _pickerBase = pickerBase;
            
            AssetManager.Instance.LoadPlatformPrefabs();
            
            _pickerBase.Initialize();
        }

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            
        }
    }
}
