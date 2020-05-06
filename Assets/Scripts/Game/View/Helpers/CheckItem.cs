using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Helpers
{
    public class CheckItem : MonoBehaviour
    {
        private Image _checkImage;

        public bool IsActive;
        
        public void Initialize()
        {
            _checkImage = GetComponent<Image>();
            IsActive = false;
        }

        public void Active()
        {
            IsActive = true;
            _checkImage.color = Color.yellow;
        }

        public void Deactive()
        {
            IsActive = false;
            _checkImage.color = Color.white;
        }
    }
}
