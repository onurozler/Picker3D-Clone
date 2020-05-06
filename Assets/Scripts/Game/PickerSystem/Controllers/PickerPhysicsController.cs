using System;
using Game.CollectableSystem;
using Game.PickerSystem.Managers;
using UnityEngine;

namespace Game.PickerSystem.Controllers
{
    public class PickerPhysicsController : MonoBehaviour
    {
        private PickerPhysicsManager _pickerPhysicsManager;
        
        public void Initialize(PickerPhysicsManager pickerPhysicsManager)
        {
            _pickerPhysicsManager = pickerPhysicsManager;
        }

        public void PushCollectables()
        {
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
