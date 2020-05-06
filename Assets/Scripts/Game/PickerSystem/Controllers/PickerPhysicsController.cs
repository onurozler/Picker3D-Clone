﻿using System;
using Game.CollectableSystem;
using Game.PickerSystem.Managers;
using UnityEngine;
using Utils;

namespace Game.PickerSystem.Controllers
{
    public class PickerPhysicsController : MonoBehaviour
    {
        private PickerPhysicsManager _pickerPhysicsManager;
        private PickerMovementController _pickerMovementController;
        
        public void Initialize(PickerPhysicsManager pickerPhysicsManager, PickerMovementController pickerMovementController)
        {
            _pickerPhysicsManager = pickerPhysicsManager;
            _pickerMovementController = pickerMovementController;
        }

        public void PushCollectables()
        {
            _pickerMovementController.Deactivate();
            Timer.Instance.TimerWait(2f, () => _pickerMovementController.Activate());
            
            foreach (var collectable in _pickerPhysicsManager.GetCollectables())
            {
                collectable.Push();
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            var collectable = other.GetComponent<CollectableBase>();
            if (collectable != null)
            {
                _pickerPhysicsManager.AddCollectable(collectable);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var collectable = other.GetComponent<CollectableBase>();
            if (collectable != null)
            {
                _pickerPhysicsManager.RemoveCollectable(collectable);
            }
        }
    }
}
