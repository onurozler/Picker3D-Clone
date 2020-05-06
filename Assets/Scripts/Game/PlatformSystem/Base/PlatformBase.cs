using UnityEngine;

namespace Game.PlatformSystem.Base
{
    public abstract class PlatformBase : MonoBehaviour
    {
        public abstract PlatformType PlatformType { get; }

        public virtual void Initialize()
        {
            
        }
    }

    public enum PlatformType
    {
        NORMAL,
        CHECKPOINT,
        FINAL
    }
}
