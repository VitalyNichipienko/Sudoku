using System;
using System.Collections.Generic;
using UI.Windows;
using UnityEngine;
using Zenject;

namespace Core.Infrastructure.UiManagement
{
    public class WindowsPool : MonoBehaviour
    {
        [SerializeField] private Canvas root;

        private WindowsPrefabsContainer _windowsPrefabsContainer;

        private Dictionary<Type, Window> _cachedWindows = new();
        private CommonFactory _commonFactory;

        [Inject]
        public void Construct(CommonFactory commonFactory, WindowsPrefabsContainer prefabsContainer)
        {
            _commonFactory = commonFactory;
            _windowsPrefabsContainer = prefabsContainer;
        }

        public T Get<T>() where T : Window
        {
            return (T) Get(typeof(T));
        }
        
        public Window Get(Type type)
        {
            if (_cachedWindows.TryGetValue(type, out Window windowBase))
                return windowBase;

            if (_windowsPrefabsContainer.TryGet(type, out Window prefab))
            {
                var instance =  _commonFactory.Instantiate(prefab, root.transform);
                _cachedWindows.Add(type, instance);
                return instance;
            }

            throw new Exception("Cannot find window prefab");
        }
        
        public void Destroy<T>() where T : Window
        {
            Destroy(typeof(T));
        }
        
        private void Destroy(Type type)
        {
            if (_cachedWindows.TryGetValue(type, out Window windowBase))
            {
                UnityEngine.GameObject.Destroy(windowBase.gameObject);
                _cachedWindows.Remove(type);
            }
        }
    }
}