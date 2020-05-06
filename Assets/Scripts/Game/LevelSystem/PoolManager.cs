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

        public void Initialize()
        {
            _platformBases = new List<PlatformBase>();
        }
        
        public PlatformBase GetCreamAvailableCream(PlatformType platformType)
        {
            var platform = _platformBases?.FirstOrDefault(x => !x.IsActive);
            if (platform == null)
            {
                platform = Instantiate(AssetManager.Instance.GetPlatform(platformType), transform);
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
