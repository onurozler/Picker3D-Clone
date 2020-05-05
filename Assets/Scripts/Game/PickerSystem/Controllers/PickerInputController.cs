using System;
using UnityEngine;
using Utils;

namespace Game.PickerSystem.Controllers
{
    public class PickerInputController : MonoBehaviour
    {
        public Action<float> OnMousePressing;
        public Action OnMouseReleasing;

        private Camera _pickerCamera;
        private Vector3 _mousePos;
        private float _distanceToScreen;
        private float _xThreshHold;

        public void Initialize(Camera cam)
        {
            _pickerCamera = cam;
            _xThreshHold = 3f;
        }
        
        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                var position = Input.mousePosition;
                if (position.x > 0 && position.x < Screen.width)
                {
                    _distanceToScreen = _pickerCamera.WorldToScreenPoint(gameObject.transform.position).z;
                    _mousePos = _pickerCamera.ScreenToWorldPoint(new Vector3(position.x, position.y, _distanceToScreen ));
                    var xPos = _mousePos.x;
                    if(xPos > _xThreshHold || xPos < -_xThreshHold)
                        xPos = Mathf.Clamp(_mousePos.x, -_xThreshHold+0.2f, _xThreshHold);
                    
                    OnMousePressing.SafeInvoke(xPos);
                }
            }
            
            OnMouseReleasing.SafeInvoke();
        }
    }
}
