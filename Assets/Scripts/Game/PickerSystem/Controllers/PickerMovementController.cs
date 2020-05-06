using System;
using DG.Tweening;
using UnityEngine;

namespace Game.PickerSystem.Controllers
{
    public class PickerMovementController : MonoBehaviour
    {
        private float _speed;
        private PickerInputController _pickerInputController;
        
        public void Initialize(PickerInputController pickerInputController )
        {
            _speed = 2f;
            _pickerInputController = pickerInputController;

            _pickerInputController.OnMousePressing += MovePicker;
            _pickerInputController.OnMouseReleasing += MoveForward;
        }

        private void MovePicker(float mouseX)
        {
            transform.DOMoveX(mouseX, 0.5f);
        }

        private void MoveForward()
        {
            transform.DOMoveZ(transform.position.z + 1f, 0.5f);
        }
        
    }
}
