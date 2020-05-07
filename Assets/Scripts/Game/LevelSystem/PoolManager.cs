using System.Collections.Generic;
using System.Linq;
using Game.Managers;
using Game.PlatformSystem.Base;
using UnityEngine;

namespace Game.LevelSystem
{
    public class PoolManager : MonoBehaviour
    {
        private List<PlatformBase> _platformBases;

        public PlatformBase GetAvailablePlatform(PlatformType platformType)
        {
            if(_platformBases == null)
                _platformBases = new List<PlatformBase>();
            
            var platform = _platformBases?.FirstOrDefault(x => !x.IsActive);
            if (platform == null)
            {
                platform = AssetManager.Instance.GetPlatform(platformType);
                platform.Initialize();
                platform = Instantiate(platform, transform);
                _platformBases?.Add(platform);
            }
            
            platform.Activate();
            return platform;
        }

        public void DeactivateWholePool()
        {
            if(_platformBases.Count <= 0)
                return;
            
            foreach (var platform in _platformBases)
            {
                platform.Deactivate();
            }
        }
    }
}
