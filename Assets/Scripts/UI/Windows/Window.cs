using UnityEngine;

namespace UI.Windows
{
    public abstract class Window : MonoBehaviour
    {
        [SerializeField] protected Canvas root;
        
        public abstract void Show();
        public abstract void Hide();
    }
}
