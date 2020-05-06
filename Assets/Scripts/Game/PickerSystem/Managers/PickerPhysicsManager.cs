using System.Collections.Generic;
using Game.CollectableSystem;

namespace Game.PickerSystem.Managers
{
    public class PickerPhysicsManager
    {
        private List<CollectableBase> _collectables;

        public PickerPhysicsManager()
        {
            _collectables = new List<CollectableBase>();
        }

        public void AddCollectable(CollectableBase collectableBase)
        {
            _collectables.Add(collectableBase);
        }

        public void RemoveCollectable(CollectableBase collectableBase)
        {
            _collectables.Remove(collectableBase);
        }

        public List<CollectableBase> GetCollectables()
        {
            return _collectables;
        }
        
        public void Clear()
        {
            _collectables.Clear();
        }
    }
}
