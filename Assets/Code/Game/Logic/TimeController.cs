using Assets.Code.Common;
using Assets.Code.Game.Model;
using Assets.Code.Game.View;
using Assets.Code.Networking;
using System.Collections;
using UnityEngine;

namespace Assets.Code.Game.Logic
{
    public class TimeController
    {
        private readonly ITimeProvider _provider;
        private readonly Timer _timer;
        private readonly ClockController _clockController;

        private readonly Transform _secondHand;
        private readonly Transform _minuteHand;
        private readonly Transform _hourHand;

        private readonly TimeAnimator _timeAnimator;
        private readonly TimeWriter _timeWriter;

        private readonly ICoroutineRunner _runner;

        private Coroutine _timeViewUpdate;

        public TimeController(ICoroutineRunner runner, Timer timer, TimeAnimator timeAnimator, TimeWriter timeWriter, ITimeProvider provider, ClockController clockController)
        {
            _runner = runner;
            _timer = timer;
            _timeAnimator = timeAnimator;
            _timeWriter = timeWriter;
            _provider = provider;
            _clockController = clockController;
        }

        public void Start()
        {
            _provider.Update(SetTimeFromServer);
            _timeViewUpdate = _runner.StartCoroutine(TimeViewUpdate());
            _timeAnimator.StartAnimation();
        }

        private void SetTimeFromServer()
        {
            _timeAnimator.StopAnimation();
            _runner.StopCoroutine(_timeViewUpdate);

            _timer.SetTime(_provider.ServerTime);
            _clockController.SetPositions(_timer.Data);

            _timeViewUpdate = _runner.StartCoroutine(TimeViewUpdate());
            _timeAnimator.StartAnimation();
        }

        private IEnumerator TimeViewUpdate()
        {
            WaitForSecondsRealtime delay = new(1f);

            while (true)
            {
                Debug.Log(_timer.Data);
                _timeWriter.Show(_timer.Data);

                yield return delay;
            }
        }
    }
}