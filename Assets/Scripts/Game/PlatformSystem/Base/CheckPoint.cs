using System;
using Game.PickerSystem.Controllers;
using UnityEngine;

namespace Game.PlatformSystem.Base
{
    public class CheckPoint : PlatformBase
    {
        public override PlatformType PlatformType => PlatformType.CHECKPOINT;

        private CheckPointCounterPlatform _checkPointCounterPlatform;

        private void Awake()
        {
            Initialize();
        }

        public override void Initialize()
        {
            base.Initialize();
            _checkPointCounterPlatform = GetComponentInChildren<CheckPointCounterPlatform>();
            _checkPointCounterPlatform.Initialize();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var picker = other.GetComponent<PickerPhysicsController>();
            if (picker != null)
            {
                _checkPointCounterPlatform.SetTarget(10);
                picker.PushCollectables();
            }
        }
    }
}
