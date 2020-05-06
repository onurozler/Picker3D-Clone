using UnityEngine;

namespace Game.CollectableSystem
{
    public class CollectableBase : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Push()
        {
            _rigidbody.AddForceAtPosition(Vector3.forward * 20,transform.position);
        }
    }
}
