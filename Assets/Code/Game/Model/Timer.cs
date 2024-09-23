using Assets.Code.Common;
using System;
using UnityEngine;

namespace Assets.Code.Game.Model
{
    public class Timer
    {
        private readonly ICoroutineRunner _runner;

        public DateTime Data { get; private set; }

        public Timer(ICoroutineRunner coroutineRunner)
        {
            _runner = coroutineRunner;
            Data = new();

            //_runner.StartCoroutine(Working());
        }

        public void Update()
        {
            Data = Data.AddSeconds(Time.deltaTime);
        }

        public void SetTime(DateTime time)
        {
            Data = time;

        }

        //private IEnumerator Working()
        //{
        //    float delaySecond = 1f;
        //    WaitForSeconds delay = new(delaySecond);

        //    while (true)
        //    {
        //        yield return null;
        //        Data = Data.AddSeconds(Time.deltaTime);
        //        Debug.Log(Data.Second + " Timer");
        //    }
        //}
    }
}
