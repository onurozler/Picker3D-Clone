using System.Collections.Generic;
using System.Linq;
using Game.CollectableSystem;
using UnityEngine;

namespace Game.LevelSystem.BallPacks
{
    public class BallPackBase : MonoBehaviour
    {
        public bool IsActive;
        public BallPackType BallPackType;

        private List<CollectableBase> _collectableBases;
        private Vector3 _packPosition;
        private List<Vector3> _positions;
        
        public void Initialize()
        {
            _collectableBases = GetComponentsInChildren<CollectableBase>(true).ToList();
            _packPosition = transform.position;
            _positions = new List<Vector3>(_collectableBases.Count);
            foreach (var t in _collectableBases)
            {
                _positions.Add(t.transform.localPosition);
            }

            IsActive = false;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            IsActive = true;
            
            transform.position = _packPosition;
            for (int i = 0; i < _collectableBases.Count; i++)
            {
                _collectableBases[i].transform.localPosition = _positions[i];
                _collectableBases[i].Activate();
            }
        }

        public void Deactivate()
        {
            IsActive = false;
            gameObject.SetActive(false);
        }
    }

    public enum BallPackType
    {
        RECTANGLE,
        TOWER,
        MIXED
    }
}
