using Game.GameEvents;
using UnityEngine;

namespace Game.PlatformSystem.Base
{
    public abstract class PlatformBase : MonoBehaviour
    {
        public abstract PlatformType PlatformType { get; }
        public bool IsActive;
        public virtual void Initialize()
        {
            IsActive = false;
        }
        
        public void Activate()
        {
            IsActive = true;
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
        
    }

    public enum PlatformType
    {
        NORMAL,
        CHECKPOINT,
        FINAL
    }
}
