using DG.Tweening;
using Game.GameEvents;
using Game.PickerSystem.Controllers;
using Game.PlatformSystem.CheckPointControllers;
using UnityEngine;
using Utils;

namespace Game.PlatformSystem.Base
{
    public class CheckPoint : PlatformBase
    {
        public override PlatformType PlatformType => PlatformType.CHECKPOINT;
        private int _target;

        private CheckPointCounterPlatform _checkPointCounterPlatform;
        private Transform _gate1;
        private Transform _gate2;
        private Vector3 _firstPosGate1;
        private Vector3 _firstPosGate2;

        public void SetTarget(int aim)
        {
            _target = aim;
            _checkPointCounterPlatform = GetComponentInChildren<CheckPointCounterPlatform>(true);            
            _gate1 = transform.Find("Gate1");
            _gate2 = transform.Find("Gate2");

            _checkPointCounterPlatform.Initialize(_target);
            
            GameEventBus.SubscribeEvent(GameEventType.FINISHED,Reset);
        }

        private void CheckContinue()
        {
            if (_checkPointCounterPlatform.GetCounter() >= _target)
            {
                _checkPointCounterPlatform.SuccesfulAction();
                _gate1.transform.DORotate(new Vector3(-60,90,90), 1f);
                _gate2.transform.DORotate(new Vector3(60,90,90), 1f).OnComplete(()=>
                {
                    GameEventBus.InvokeEvent(GameEventType.CHECKPOINT);
                });
                
            }
            else
            {
                Debug.Log("Fail");
                
                GameEventBus.InvokeEvent(GameEventType.FAIL);
            }
        }

        private void Reset()
        {
            _gate1.transform.eulerAngles = new Vector3(0,90,90);
            _gate2.transform.eulerAngles = new Vector3(0,90,90);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var picker = other.GetComponent<PickerPhysicsController>();
            if (picker != null)
            {
                picker.PushCollectables();
                Timer.Instance.TimerWait(2f, CheckContinue);
            }
        }
    }
}
