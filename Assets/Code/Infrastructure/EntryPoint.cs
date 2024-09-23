using Assets.Code.Common;
using Assets.Code.Networking;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Infrastructure
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        public Button testButton;

        private TimeProvider _timeProvider;
        private ErrorHandler _errorHandler;

        private void Awake()
        {
            Create();
            Initialization();

            testButton.onClick.AddListener(OnTest);
        }

        private void OnDestroy()
        {
            _errorHandler.Dispose();
            testButton.onClick.RemoveListener(OnTest);
        }

        private void OnTest()
        {
            _timeProvider.Update(Massage);
            Debug.Log("OnTest " + _timeProvider.ServerTime);
        }

        private void Massage()
        {
            Debug.Log(_timeProvider.ServerTime);
        }

        private void Create()
        {
            _timeProvider = new(this);
            _errorHandler = new(_timeProvider);
        }

        private void Initialization()
        {

        }
    }
}