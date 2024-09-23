using System;
using UnityEngine;

namespace Assets.Code.Networking
{
    public class ErrorHandler : IDisposable
    {
        private readonly IErrorProvider _provider;

        public ErrorHandler(IErrorProvider provider)
        {
            _provider = provider;

            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void OnErrorGettingTime(string message)
        {
#if UNITY_EDITOR
            Debug.Log($"Ошибка получения времени: {message}");
#else
#endif
        }

        private void OnErrorDataDeserialization(Exception exception)
        {
#if UNITY_EDITOR
            Debug.Log($"Ошибка обработки данных: {exception.Message}");
#else
#endif
        }

        private void Subscribe()
        {
            _provider.ErrorTimeGetting += OnErrorGettingTime;
            _provider.ErrorDataDeserialization += OnErrorDataDeserialization;
        }

        private void Unsubscribe()
        {
            _provider.ErrorTimeGetting -= OnErrorGettingTime;
            _provider.ErrorDataDeserialization -= OnErrorDataDeserialization;
        }
    }
}
