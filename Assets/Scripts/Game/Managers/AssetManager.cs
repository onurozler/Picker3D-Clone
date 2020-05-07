using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Game.LevelSystem;
using Game.LevelSystem.BallPacks;
using Game.PlatformSystem.Base;
using Helpers;
using UnityEngine;

namespace Game.Managers
{
    public class AssetManager : GenericSingleton<AssetManager>
    {
        private const string LEVEL_PATH = "Levels/Level";
        private const string BALLPACK_PATH = "BallPacks";
        private const string PLATFORM_PATH = "PlatformPrefabs";

        private List<PlatformBase> _platformBases;
        private List<BallPackBase> _ballPackBases;
        
        public Material GroundMaterial;
        public Material PickerMaterial;

        public void LoadPlatformPrefabs()
        {
            _platformBases = Resources.LoadAll<PlatformBase>(PLATFORM_PATH).ToList();
            _ballPackBases = Resources.LoadAll<BallPackBase>(BALLPACK_PATH).ToList();
        }

        public PlatformBase GetPlatform(PlatformType platformType)
        {
            return _platformBases?.FirstOrDefault(x => x.PlatformType == platformType);
        }

        public BallPackBase GetBallPack(BallPackType ballPackType)
        {
            return _ballPackBases?.FirstOrDefault(x => x.BallPackType == ballPackType);
        }
        
        public LevelData LoadLevel(int levelindex)
        {
            return Resources.Load<LevelData>(LEVEL_PATH + levelindex);
        }
    }
}
