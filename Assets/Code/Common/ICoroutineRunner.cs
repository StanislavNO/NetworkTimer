using System.Collections;
using UnityEngine;

namespace Assets.Code.Common
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
    }
}