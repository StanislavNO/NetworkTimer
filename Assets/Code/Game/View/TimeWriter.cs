using System;
using TMPro;
using UnityEngine;

namespace Assets.Code.Game.View
{
    public class TimeWriter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _timeDisplay;

        public void Show(DateTime currentTime)
        {

            _timeDisplay.text = currentTime.ToString("HH:mm:ss");
            Debug.Log(currentTime.Second + "timeWriter");
        }
    }
}