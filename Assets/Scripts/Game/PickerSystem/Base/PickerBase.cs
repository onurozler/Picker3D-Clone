using Game.PickerSystem.Controllers;
using UnityEngine;

namespace Game.PickerSystem.Base
{
    public class PickerBase : MonoBehaviour
    {
        private Camera _pickerCamera;
        private Rigidbody _pickerRigidbody;
        private Vector3 _cameraOffset;

        
        private PickerMovementController _pickerMovementController;
        private PickerInputController _pickerInputController;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _pickerCamera = _pickerCamera == null ? Camera.main : _pickerCamera;
            _cameraOffset = _pickerCamera.transform.position - transform.position;
            
            _pickerRigidbody = GetComponentInChildren<Rigidbody>();
            _pickerInputController = GetComponent<PickerInputController>();
            _pickerMovementController = GetComponent<PickerMovementController>();
            
            _pickerInputController.Initialize(_pickerCamera);
            _pickerMovementController.Initialize(_pickerInputController);
        }
        
        private void LateUpdate()
        {
            if(_pickerCamera == null)
                return;
            
            _pickerCamera.transform.position = new Vector3(_pickerCamera.transform.position.x,_pickerCamera.transform.position.y,
                transform.position.z + _cameraOffset.z);
        }
    }
}
