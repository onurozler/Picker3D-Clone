using System.Collections.Generic;
using System.Linq;
using Game.CollectableSystem;
using Game.GameEvents;
using UnityEngine;

namespace Game.LevelSystem.BallPacks
{
    public class BallPackBase : MonoBehaviour
    {
        public bool IsActive;
        public BallPackType BallPackType;

        private List<CollectableBase> _collectableBases;
        private List<Vector3> _positions;
        
        public void Initialize()
        {
            _collectableBases = GetComponentsInChildren<CollectableBase>(true).ToList();
            _positions = new List<Vector3>(_collectableBases.Count);
            foreach (var t in _collectableBases)
            {
                _positions.Add(t.transform.position);
            }

            IsActive = false;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            IsActive = true;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            IsActive = false;
            for (int i = 0; i < _collectableBases.Count; i++)
            {
                _collectableBases[i].transform.position = _positions[i];
                _collectableBases[i].Activate();
            }
        }
    }

    public enum BallPackType
    {
        RECTANGLE,
        TOWER,
        MIXED
    }
}
