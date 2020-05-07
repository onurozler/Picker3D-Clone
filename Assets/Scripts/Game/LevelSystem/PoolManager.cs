using System.Collections.Generic;
using System.Linq;
using Game.LevelSystem.BallPacks;
using Game.Managers;
using Game.PlatformSystem.Base;
using UnityEngine;

namespace Game.LevelSystem
{
    public class PoolManager : MonoBehaviour
    {
        private List<PlatformBase> _platformBases;
        private List<BallPackBase> _ballPackBases;

        public PlatformBase GetAvailablePlatform(PlatformType platformType)
        {
            if(_platformBases == null)
                _platformBases = new List<PlatformBase>();
            
            var platform = _platformBases?.FirstOrDefault(x => !x.IsActive && x.PlatformType == platformType);
            if (platform == null)
            {
                platform = AssetManager.Instance.GetPlatform(platformType);
                platform = Instantiate(platform, transform);
                platform.Initialize();
                _platformBases?.Add(platform);
            }
            
            platform.Activate();
            return platform;
        }

        public BallPackBase GetAvailableBallPack(BallPackType ballPackType)
        {
            if(_ballPackBases == null)
                _ballPackBases = new List<BallPackBase>();

            var ball = _ballPackBases?.FirstOrDefault(x => !x.IsActive && x.BallPackType == ballPackType);
            if (ball == null)
            {
                ball = AssetManager.Instance.GetBallPack(ballPackType);
                ball = Instantiate(ball, transform);
                ball.Initialize();
                _ballPackBases?.Add(ball);
            }
            
            ball.Activate();
            return ball;
        }
        

        public void DeactivateWholePool()
        {
            if(_platformBases.Count <= 0)
                return;
            
            foreach (var platform in _platformBases)
            {
                platform.Deactivate();
            }

            foreach (var ball in _ballPackBases)
            {
                ball.Deactivate();
            }
        }
    }
}
