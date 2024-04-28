using System;
using System.Collections;
using Core.Infrastructure.Services.CoroutineRunner;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Core.Infrastructure.SceneLoad
{
    public class SceneLoader
    {
        private const float SceneLoadOperationMaxProgress = 0.9f;
        
        private readonly ICoroutineRunner _coroutineRunner;

        private bool _canBeLoaded;

        [Inject]
        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void Load(LoadingScenes scene, Action onLoaded = null) => 
            _coroutineRunner.StartCoroutine(LoadScene(scene.ToString(), onLoaded));

        private IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            waitNextScene.allowSceneActivation = false;
            
            float progress = 0;
 
            while (!waitNextScene.isDone)
            {
                progress = Mathf.MoveTowards(progress, waitNextScene.progress, Time.deltaTime);
                if (progress >= SceneLoadOperationMaxProgress)
                {
                    progress = 1;
                    waitNextScene.allowSceneActivation = true;
                }
                
                yield return null;
            }
            
            onLoaded?.Invoke();
        }
    }
}