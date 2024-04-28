using UnityEngine;

namespace Core.Infrastructure.Services.CoroutineRunner
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        private void Awake() => 
            DontDestroyOnLoad(this);
    }
}
