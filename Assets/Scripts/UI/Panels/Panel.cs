using System;
using UnityEngine;

namespace UI.Panels
{
    public abstract class Panel : MonoBehaviour
    {
        public event Action PanelShown;
        public event Action PanelHidden;
        
        public virtual void Show()
        {
            gameObject.SetActive(true);
            
            PanelShown?.Invoke();
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            
            PanelHidden?.Invoke();
        }
    }
}
