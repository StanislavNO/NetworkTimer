using Assets.Code.Common;
using Newtonsoft.Json;
using System;
using System.Collections;
using UnityEngine.Networking;

namespace Assets.Code.Networking
{
    public class TimeProvider : ITimeProvider, IErrorProvider
    {
        public event Action<string> ErrorTimeGetting;
        public event Action<Exception> ErrorDataDeserialization;

        private readonly ICoroutineRunner _runner;

        public DateTime ServerTime { get; private set; }

        public TimeProvider(ICoroutineRunner coroutineRunner)
        {
            _runner = coroutineRunner;
        }

        public void Update(Action Complied) =>
            _runner.StartCoroutine(GetTimeFromServer(Complied));

        private IEnumerator GetTimeFromServer(Action Complied)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(Url.Yandex))
            {
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    ErrorTimeGetting?.Invoke(request.error);
                }
                else
                {
                    try
                    {
                        string json = LoadJson(request);
                        TimeData timeData = Convert<TimeData>(json);

                        SetTime(timeData);
                        Complied.Invoke();
                    }
                    catch (Exception exception)
                    {
                        ErrorDataDeserialization?.Invoke(exception);
                    }
                }
            }
        }

        private string LoadJson(UnityWebRequest request) =>
            request.downloadHandler.text;

        private T Convert<T>(string json) =>
            JsonConvert.DeserializeObject<T>(json);

        private void SetTime(TimeData timeData) =>
            ServerTime = DateTimeOffset.FromUnixTimeMilliseconds(timeData.Time).UtcDateTime;
    }
}