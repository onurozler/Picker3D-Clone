using System.Collections.Generic;
using System.Linq;
using Game.LevelSystem;
using Game.PlatformSystem.Base;
using Helpers;
using UnityEngine;

namespace Game.Managers
{
    public class AssetManager : GenericSingleton<AssetManager>
    {
        private const string LEVEL_PATH = "Levels/Level";
        private const string PLATFORM_PATH = "PlatformPrefabs";

        private List<PlatformBase> _platformBases;
        
        public Material GroundMaterial;

        public void LoadPlatformPrefabs()
        {
            _platformBases = Resources.LoadAll<PlatformBase>(PLATFORM_PATH).ToList();
        }

        public LevelData LoadLevel(int levelindex)
        {
            return Resources.Load<LevelData>(LEVEL_PATH + levelindex);
        }
    }
}
