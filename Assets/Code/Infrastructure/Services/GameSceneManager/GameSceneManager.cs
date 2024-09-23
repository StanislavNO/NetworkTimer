using Assets.Code.Common;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Infrastructure.Services.GameSceneManager
{
    public class GameSceneManager
    {
        private readonly ICoroutineRunner _runner;

        public GameSceneManager(ICoroutineRunner runner)
        {
            _runner = runner;
        }

        public void ReloadCurrentScene() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        public void LoadGameSceneAsync(Action loadComplete = null) =>
            _runner.StartCoroutine(LoadSceneAsync(loadComplete));

        private IEnumerator LoadSceneAsync(Action loadComplete)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync((int)SceneNames.Game);

            while (asyncLoad.isDone == false)
                yield return null;

            loadComplete?.Invoke();
        }
    }
}