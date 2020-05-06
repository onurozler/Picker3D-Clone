using DG.Tweening;
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

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
        
        public void Push()
        {
            _rigidbody.DOMoveZ(transform.position.z + 8f, 1f);
        }
    }
}
