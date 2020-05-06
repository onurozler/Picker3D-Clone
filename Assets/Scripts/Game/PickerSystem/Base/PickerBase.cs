using Game.PickerSystem.Controllers;
using Game.PickerSystem.Managers;
using UnityEngine;

namespace Game.PickerSystem.Base
{
    public class PickerBase : MonoBehaviour
    {
        private Camera _pickerCamera;
        private Vector3 _cameraOffset;


        private PickerPhysicsManager _pickerPhysicsManager;

        private PickerPhysicsController _pickerPhysicsController;
        private PickerMovementController _pickerMovementController;

        private void Awake()
        {
            Initialize();
        }

        public void Initialize()
        {
            _pickerCamera = _pickerCamera == null ? Camera.main : _pickerCamera;
            _cameraOffset = _pickerCamera.transform.position - transform.position;
            
            _pickerPhysicsManager = new PickerPhysicsManager();

            _pickerMovementController = GetComponent<PickerMovementController>();
            _pickerPhysicsController = GetComponent<PickerPhysicsController>();
            
            _pickerMovementController.Initialize();
            _pickerPhysicsController.Initialize(_pickerPhysicsManager);
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
