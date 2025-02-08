using Model;
using Singleton;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;
using EventType = Utility.EventType;

namespace Command
{
    public class SceneCommand : Singleton<SceneCommand>
    {
        private readonly SceneModel _sceneModel = ModelContainer.Instance.GetModel<SceneModel>();
        private bool _isLoading;

        public void LoadScene(SceneName sceneName)
        {
            if (_isLoading)
            {
                return;
            }

            _isLoading = true;
            var index = GetSceneIndexByName(sceneName);
            var op = SceneManager.LoadSceneAsync(index);
            if (op != null) op.completed += OnSceneLoaded;
        }

        public SceneName GetActiveSceneName()
        {
            return _sceneModel.SceneName;
        }

        public int GetActiveSceneIndex()
        {
            return _sceneModel.SceneIndex;
        }

        private void OnSceneLoaded(AsyncOperation obj)
        {
            _isLoading = false;
            _sceneModel.SetData(SceneManager.GetActiveScene().buildIndex);
            EventCenter.Instance.NotifyObserver(EventType.SceneLoadComplete);
        }

        private int GetSceneIndexByName(SceneName sceneName)
        {
            return sceneName switch
            {
                SceneName.MainMenuScene => 0,
                SceneName.MiddleRoomScene => 1,
                SceneName.BattleScene => 2,
                _ => 0
            };
        }
    }
}