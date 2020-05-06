using Game.PickerSystem.Controllers;
using UnityEngine;

namespace Game.PlatformSystem.Base
{
    public class CheckPoint : PlatformBase
    {
        public override PlatformType PlatformType => PlatformType.CHECKPOINT;
        
        public override void Initialize()
        {
            base.Initialize();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            var picker = other.GetComponent<PickerPhysicsController>();
            if (picker != null)
            {
                picker.PushCollectables();
            }
        }
    }
}
