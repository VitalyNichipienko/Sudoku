using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows
{
    public class Window : MonoBehaviour
    {
        [SerializeField] protected Canvas root;
        [SerializeField] protected GraphicRaycaster raycaster;

        public virtual void Show()
        {
            raycaster.enabled = true;
            root.enabled = true;
        }

        public virtual void Hide()
        {
            raycaster.enabled = false;
            root.enabled = false;
        }
    }
}
