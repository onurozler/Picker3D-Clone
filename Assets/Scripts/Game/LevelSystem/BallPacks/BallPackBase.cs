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
            
            PhysicsActivision(true);
        }

        public void Deactivate()
        {
            IsActive = false;
            gameObject.SetActive(false);
            PhysicsActivision(false);
        }

        private void PhysicsActivision(bool check)
        {
            /* Sometimes when we reset balls, their position may change a bit because of physics interactions,
              thats why better to implement to make off physics, put correct position and open the physics */
            foreach (var collectableBase in _collectableBases)
            {
                collectableBase.GetComponent<Rigidbody>().isKinematic = !check;
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
