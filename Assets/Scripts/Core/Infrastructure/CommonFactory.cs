using UnityEngine;
using Zenject;

namespace Core.Infrastructure
{
    public class CommonFactory
    {
        private readonly DiContainer _diContainer;

        public CommonFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        
        public T Instantiate<T>(T obj, Transform parent) where T : MonoBehaviour
        {
            return _diContainer.InstantiatePrefabForComponent<T>(obj, parent);
        }
    }
}