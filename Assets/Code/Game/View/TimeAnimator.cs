using DG.Tweening;
using UnityEngine;

namespace Assets.Code.Game.View
{
    public class TimeAnimator : MonoBehaviour
    {
        [SerializeField] private Transform _secondHand;
        [SerializeField] private Transform _minuteHand;
        [SerializeField] private Transform _hourHand;

        private Tween _minuteHandTween;
        private Tween _secondHandTween;
        private Tween _hourHandTween;

        public void StartAnimation()
        {
            int loops = -1;
            float fullAngle = 360;

            Vector3 targetSecondRotation = -Vector3.forward * (_secondHand.eulerAngles.z + fullAngle);
            Vector3 targetMinuteRotation = -Vector3.forward * (_minuteHand.eulerAngles.z + fullAngle);
            Vector3 targetHourRotation = -Vector3.forward * (_hourHand.eulerAngles.z + fullAngle);

            _secondHandTween = _secondHand
                .DORotate(targetSecondRotation, HandSpeed.Second, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(loops, LoopType.Restart);

            _minuteHandTween = _minuteHand
                .DORotate(targetMinuteRotation, HandSpeed.Minute, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(loops, LoopType.Restart);

            _hourHandTween = _hourHand
                .DORotate(targetHourRotation, HandSpeed.Hour, RotateMode.FastBeyond360)
                .SetEase(Ease.Linear)
                .SetLoops(loops,LoopType.Restart);
        }

        public void StopAnimation()
        {
            if (_secondHandTween != null && _secondHandTween.IsActive())
                _secondHandTween.Kill();

            if (_minuteHandTween != null && _minuteHandTween.IsActive())
                _minuteHandTween.Kill();

            if (_hourHandTween != null && _hourHandTween.IsActive())
                _hourHandTween.Kill();
        }
    }
}