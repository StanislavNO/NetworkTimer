using System;
using UnityEngine;

namespace Assets.Code.Game.Logic
{
    public class ClockController : MonoBehaviour
    {
        [SerializeField] private Transform _secondHand;
        [SerializeField] private Transform _minuteHand;
        [SerializeField] private Transform _hourHand;

        public void SetPositions(DateTime time)
        {
            _secondHand.rotation = Quaternion.Euler(-Vector3.forward * Convert(time.Second, 60));
            _minuteHand.rotation = Quaternion.Euler(-Vector3.forward * Convert(time.Minute, 60));
            _hourHand.rotation = Quaternion.Euler(-Vector3.forward * Convert(time.Hour, 12));
            Debug.Log(time.Second + "clockController");
        }

        private float Convert(int time, int maxTime)
        {
            float fullAngle = 360;
            float rotationZ = fullAngle / maxTime * time;
            return rotationZ;
        }
    }
}