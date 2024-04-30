using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Window : MonoBehaviour
    {
        [SerializeField] protected Canvas root;
        [SerializeField] protected GraphicRaycaster raycaster;

        public event Action WindowShown;
        public event Action WindowHidden;

        public virtual void Show()
        {
            raycaster.enabled = true;
            root.enabled = true;
            
            WindowShown?.Invoke();
        }

        public virtual void Hide()
        {
            raycaster.enabled = false;
            root.enabled = false;
            
            WindowHidden?.Invoke();
        }
    }
}
