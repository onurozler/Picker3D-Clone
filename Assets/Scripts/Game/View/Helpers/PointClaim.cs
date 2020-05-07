using UnityEngine;
using UnityEngine.UI;

namespace Game.View.Helpers
{
    public class PointClaim : MonoBehaviour
    {
        private Text _text;
        
        public void Initialize()
        {
            _text = GetComponentInChildren<Text>();
        }

        public void ChangePoint(int point)
        {
            _text.text = point.ToString();
        }
    }
}
