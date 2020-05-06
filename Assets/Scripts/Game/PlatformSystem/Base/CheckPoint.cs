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
    }
}
