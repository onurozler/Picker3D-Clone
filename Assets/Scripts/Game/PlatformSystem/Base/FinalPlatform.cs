using Game.GameEvents;
using Game.PickerSystem.Controllers;
using UnityEngine;
using Utils;

namespace Game.PlatformSystem.Base
{
    public class FinalPlatform : PlatformBase
    {
        public override PlatformType PlatformType => PlatformType.FINAL;

        private void OnTriggerEnter(Collider other)
        {
            var picker = other.GetComponent<PickerPhysicsController>();
            if (picker != null)
            {
                Debug.Log("Finished!");

                Timer.Instance.TimerWait(2f, () => GameEventBus.InvokeEvent(GameEventType.FINISHED));
            }
        }
    }
}
