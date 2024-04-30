using System;
using System.Linq;
using UI.Windows;
using UnityEngine;

namespace Core.Infrastructure.UiManagement
{
    [CreateAssetMenu(menuName = "Containers/Create windows prefabs container", fileName = "WindowsPrefabsContainer")]
    public class WindowsPrefabsContainer : ScriptableObject
    {
        [SerializeField] private Window[] prefabs;

        public bool TryGet(Type type, out Window result)
        {
            Window windowBase = prefabs.First(x => x.GetType() == type);
            result = windowBase;
            return windowBase != null;
        }
    }
}