using System.Collections;
using UnityEngine;

namespace Core.Infrastructure.Services.CoroutineRunner
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}