using System;
using System.Collections.Generic;
using UI.Windows;
using Object = UnityEngine.Object;

namespace Core.Infrastructure.UiManagement
{
    public class UiManager
    {
        private int _currentSortingOrder;
        private WindowsPool _windowsPool;
        private Dictionary<Type, Window> _createdWindows = new();

        private WindowsPool WindowsPool
        {
            get
            {
                if (_windowsPool == null || _windowsPool.gameObject == null)
                {
                    _windowsPool = Object.FindObjectOfType<WindowsPool>();
                }

                return _windowsPool;
            }
        }
        
        public void ShowWindow<T>() where T : Window
        {
            HideAllWindows();

            Window window = GetOrCreateWindow<T>();
            if (window != null)
            {
                window.Show();
            }
        }

        public void Clear()
        {
            _createdWindows = new();
        }
        
        private void HideAllWindows()
        {
            foreach (var window in _createdWindows.Values)
            {
                window.Hide();
            }
        }

        private Window GetOrCreateWindow<T>() where T : Window
        {
            Type windowType = typeof(T);
            if (_createdWindows.TryGetValue(windowType, out Window window))
            {
                return window;
            }

            window = WindowsPool.Get<T>();
            _createdWindows.Add(windowType, window);
            return window;
        }

        private Window GetWindow<T>() where T : Window
        {
            Type windowType = typeof(T);
            if (_createdWindows.TryGetValue(windowType, out Window window))
            {
                return window;
            }

            return null;
        }
    }
}