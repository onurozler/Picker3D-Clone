using System;
using System.Collections.Generic;
using System.Linq;
using Game.GameEvents;
using Game.View.Helpers;
using UnityEngine;

namespace Game.View
{
    public class CheckPointProgression : MonoBehaviour
    {
        private List<CheckItem> _checkItems;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _checkItems = GetComponentsInChildren<CheckItem>().ToList();
            foreach (var checkItem in _checkItems)
            {
                checkItem.Initialize();
            }
            
            GameEventBus.SubscribeEvent(GameEventType.CHECKPOINT, ActiveCheckPointItem);
            GameEventBus.SubscribeEvent(GameEventType.FINISHED, DeActivateCheckPointItem);
        }

        private void DeActivateCheckPointItem()
        {
            foreach (var item in _checkItems)
            {
                item.Deactive();
            }
        }

        private void ActiveCheckPointItem()
        {
            foreach (var item in _checkItems)
            {
                if (!item.IsActive)
                {
                    item.Active();
                    break;
                }
            }
        }
    }
}
