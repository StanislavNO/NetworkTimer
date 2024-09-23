using Assets.Code.Common;
using Assets.Code.Game.Logic;
using Assets.Code.Game.Model;
using Assets.Code.Game.View;
using Assets.Code.Networking;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Infrastructure
{
    public class EntryPoint : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private TimeAnimator _timeAnimator;
        [SerializeField] private TimeWriter _timeWriter;
        [SerializeField] private ClockController _clockController;

        public Button testButton;

        private TimeController _timeController;
        private TimeProvider _timeProvider;
        private ErrorHandler _errorHandler;
        private Timer _timer;

        private void Awake()
        {
            Create();

            testButton.onClick.AddListener(OnTest);
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
            _errorHandler.Dispose();
            testButton.onClick.RemoveListener(OnTest);
        }

        private void Start()
        {
            _timeController.Start();
        }

        private void Update()
        {
            _timer.Update();
        }

        private void OnTest()
        {
            _timeProvider.Update(Massage);
        }

        private void Massage()
        {
            Debug.Log(_timeProvider.ServerTime);
        }

        private void Create()
        {
            _timer = new(this);
            _timeProvider = new(this);
            _errorHandler = new(_timeProvider);
            _timeController = new(this, _timer, _timeAnimator, _timeWriter, _timeProvider, _clockController);
        }
    }
}