using Game.PickerSystem.Controllers;
using UnityEngine;

namespace Game.PickerSystem.Base
{
    public class PickerBase : MonoBehaviour
    {
        private Camera _pickerCamera;
        private Rigidbody _pickerRigidbody;
        
        private PickerMovementController _pickerMovementController;
        private PickerInputController _pickerInputController;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _pickerCamera = _pickerCamera == null ? Camera.main : _pickerCamera;

            _pickerRigidbody = GetComponent<Rigidbody>();
            _pickerInputController = GetComponent<PickerInputController>();
            _pickerMovementController = GetComponent<PickerMovementController>();
            
            _pickerInputController.Initialize(_pickerCamera);
            _pickerMovementController.Initialize(_pickerInputController,_pickerRigidbody);
        }
    }
}
