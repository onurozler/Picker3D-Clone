using UnityEngine;

namespace Game.PickerSystem.Controllers
{
    public class PickerMovementController : MonoBehaviour
    {
        private float _forwardSpeed;
        private float _xSpeed;

        public void Initialize()
        {
            _forwardSpeed = 5f;
            _xSpeed = 7f;
        }
        
        private void FixedUpdate()
        {
            if (Input.GetMouseButton(0))
            {
                var position = Input.mousePosition.x;
                float direction = _xSpeed;
                direction = position > Screen.width * 0.5f ? direction : -direction;
                transform.Translate(Time.deltaTime * direction,0,0);
            }
            transform.Translate(0,0,Time.deltaTime * _forwardSpeed);
        }
    }
}
