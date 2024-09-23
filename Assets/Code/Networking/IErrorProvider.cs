using System;

namespace Assets.Code.Networking
{
    public interface IErrorProvider
    {
        event Action<string> ErrorTimeGetting;
        event Action<Exception> ErrorDataDeserialization;
    }
}
