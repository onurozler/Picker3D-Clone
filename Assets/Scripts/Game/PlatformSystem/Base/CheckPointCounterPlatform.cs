using DG.Tweening;
using Game.CollectableSystem;
using TMPro;
using UnityEngine;

namespace Game.PlatformSystem.Base
{
    public class CheckPointCounterPlatform : MonoBehaviour
    {
        private int _targetCounter;
        private int _counter;
        private TextMeshPro _textMesh;

        public void Initialize()
        {
            _counter = 0;
            _targetCounter = 0;
            _textMesh = GetComponentInChildren<TextMeshPro>();
        }

        public void SetTarget(int target)
        {
            _targetCounter = target;
        }
        
        public int GetCounter()
        {
            var temp = _counter;
            _counter = 0;
            return temp;
        }
        
        private void OnCollisionEnter(Collision other)
        {
            var picker = other.gameObject.GetComponent<CollectableBase>();

            if (picker != null)
            {
                picker.Deactivate();
                DOVirtual.Float(_counter,++_counter,1f, value =>
                {
                    _textMesh.text = Mathf.RoundToInt(value) +" / " + _targetCounter;
                });
            }
        }
    }
}
