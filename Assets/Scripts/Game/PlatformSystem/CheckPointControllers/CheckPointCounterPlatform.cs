using DG.Tweening;
using Game.CollectableSystem;
using Game.Managers;
using TMPro;
using UnityEngine;

namespace Game.PlatformSystem.CheckPointControllers
{
    public class CheckPointCounterPlatform : MonoBehaviour
    {
        private int _targetCounter;
        private int _counter;
        private TextMeshPro _textMesh;
        private MeshRenderer _meshRenderer;

        public void Initialize(int target)
        {
            _counter = 0;
            _targetCounter = target;
            _textMesh = GetComponentInChildren<TextMeshPro>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _textMesh.text = Mathf.RoundToInt(_counter) +"/" + _targetCounter;
        }

        public void SuccesfulAction()
        {
            transform.DOMoveY(0, 1f);
            _textMesh.enabled = false;
            _meshRenderer.material = AssetManager.Instance.GroundMaterial;
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
                    _textMesh.text = Mathf.RoundToInt(value) +"/" + _targetCounter;
                });
            }
        }
    }
}
