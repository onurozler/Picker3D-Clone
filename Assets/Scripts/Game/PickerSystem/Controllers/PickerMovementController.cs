using UnityEngine;

namespace Game.PickerSystem.Controllers
{
    public class PickerMovementController : MonoBehaviour
    {
        private float _speed;
        private Rigidbody _pickerRigidbody;
        private PickerInputController _pickerInputController;
        
        public void Initialize(PickerInputController pickerInputController, Rigidbody pickerRigidbody)
        {
            _speed = 2f;
            _pickerInputController = pickerInputController;
            _pickerRigidbody = pickerRigidbody;

            _pickerInputController.OnMousePressing += MovePicker;
        }

        private void MovePicker(float mouseX)
        {
            _pickerRigidbody.position += transform.right * (mouseX * _speed);
        }
        
    }
}
